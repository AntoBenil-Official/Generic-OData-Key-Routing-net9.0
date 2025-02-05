# **GenericControllerTest**  

This project implements a **generic OData controller** for handling CRUD operations dynamically in a **.NET 9.0 API** using **AspNetCore.OData 9.1.3**.  

## **🌟 Expected OData Endpoints:**  

### **🔹 GET Requests:**  
- Retrieve all entities:  
  ```plaintext
  https://localhost:60928/odata/MfgUser
  ```
- Retrieve a single entity by key (Guid):  
  ```plaintext
  https://localhost:60928/odata/MfgUser(15d06324-7b5e-41ad-9dbb-791a19edb475)
  ```
  or  
  ```plaintext
  https://localhost:60928/odata/MfgUser/15d06324-7b5e-41ad-9dbb-791a19edb475
  ```

### **🔹 Other CRUD Operations (Dynamic Handling):**  
✅ **POST** – Create a new entity  
✅ **PUT** – Update an existing entity  
✅ **PATCH** – Partially update an entity  
✅ **DELETE** – Remove an entity  

## **🛠 Generic Controller:**  
- The **ManufacturingController** serves as the **generic OData controller**.  
- It dynamically handles multiple entity types and primary keys of type **Guid**.  
