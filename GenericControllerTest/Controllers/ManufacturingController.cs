using GenericControllerTest.Middleware.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using West.Manufacturing.Common.Enterprise.Models;
using West.Manufacturing.Repository.Interfaces;

namespace GenericControllerTest.Controllers
{
    [Produces("application/json")]
    [GenericControllerName]
    [EnableQuery(MaxNodeCount = 10000, AllowedQueryOptions = AllowedQueryOptions.All)]
    public class ManufacturingController<T> : ODataController where T : EnterpriseModel
    {
        protected IEnterpriseRepository<T> Repository { get; set; }

        public ManufacturingController(IEnterpriseRepository<T> Repo)
        {
            Repository = Repo;
        }

        [HttpGet]
        public async Task<IQueryable<T>> GetList([FromODataUri] bool IncludeIsArchived = false, string result = null)
        {
            if (result == "Enumerable")
            {
                var res = await Repository.GetItemsEnumerableAsync(c => (!c.IsArchived || IncludeIsArchived));
                return res.ToList().AsEnumerable().AsQueryable();
            }
            else
            {
                var res = await Repository.GetItemsAsync(c => (!c.IsArchived || IncludeIsArchived));
                return res;
            }
        }

        [HttpGet("({key})")]
        [EnableQuery]
        public async Task<IActionResult> GetSingle([FromODataUri] Guid key)
        {
            try
            {
                var result = await Repository.GetItemAsync(key.ToString());
                return Ok(result);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.ToString());
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] T item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GetModelStateError(ModelState));
            }
            try
            {
                await Repository.CreateItemAsync(item);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.ToString());
                return BadRequest(GetModelStateError(ModelState));
            }
            return Created(item);
        }

        [AcceptVerbs("PATCH")]
        public async Task<IActionResult> Patch([FromRoute] Guid key, [FromBody] Delta<T> patch)
        {
            T item = null;
            if (!ModelState.IsValid)
            {
                return BadRequest(GetModelStateError(ModelState));
            }
            try
            {
                item = await GetItem(key);
                patch.Patch(item);
                return Ok(await Repository.PatchItemAsync(key.ToString(), item));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.ToString());
                return BadRequest(GetModelStateError(ModelState));
            }
        }

        private async Task<T?> GetItem([FromODataUri] Guid key)
        {
            try
            {
                return await Repository.GetItemAsync(key.ToString());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.ToString());
                return null;
            }
        }

        [HttpPatch("({key})")]
        public async Task<IActionResult> Put([FromODataUri] Guid key, [FromBody] T item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GetModelStateError(ModelState));
            }
            if (String.IsNullOrEmpty(item.Id.ToString()))
            {
                return BadRequest();
            }
            try
            {
                return Ok(await Repository.UpdateItemAsync(item.Id.ToString(), item));
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ModelState.AddModelError("Error", ex.ToString());
                return BadRequest(GetModelStateError(ModelState));
            }
        }


        [HttpDelete("({key})")]
        public virtual async Task<IActionResult> Delete([FromRoute] Guid key, [FromRoute] bool DeleteRecord = false)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GetModelStateError(ModelState));
            }
            try
            {
                _ = await Repository.DeleteItemAsync(key.ToString(), DeleteRecord);
                return Ok();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!ItemExists(key))
                {
                    return NotFound();
                }
                else
                {
                    ModelState.AddModelError("Error", ex.ToString());
                    return BadRequest(GetModelStateError(ModelState));
                }
            }
        }

        private bool ItemExists(Guid id)
        {
            return Repository.ItemExistsAsync(id.ToString());
        }

        private List<string> GetModelStateError(ModelStateDictionary ModelState)
        {
            var errors = new List<string>();
            foreach (var state in ModelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    if (!string.IsNullOrEmpty(error.ErrorMessage))
                        errors.Add(error.ErrorMessage);
                    else if (error.Exception != null)
                        errors.Add(error.Exception.Message);
                }
            }
            return errors;
        }
    }
}
