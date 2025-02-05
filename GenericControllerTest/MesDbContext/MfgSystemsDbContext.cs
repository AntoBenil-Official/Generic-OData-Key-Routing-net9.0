using GenericControllerTest.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;
using West.Manufacturing.Model;
using West.Manufacturing.Model.Global;

namespace GenericControllerTest.MesDbContext
{
    public class MfgSystemsDbContext : DbContext
    {
        public MfgSystemsDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        /* Order Related */
        public DbSet<MfgOrder> MfgOrder { get; set; }
        public DbSet<MfgOrderComponent> MfgOrderComponent { get; set; }
        public DbSet<MfgOrderOperation> MfgOrderOperation { get; set; }
        public DbSet<MfgOrderOperationExtended> MfgOrderOperationExtended { get; set; }
        public DbSet<MfgOrderType> MfgOrderType { get; set; }
        public DbSet<MfgOrderOperationCycleSetting> MfgOrderOperationCycleSetting { get; set; }
        public DbSet<MfgOrderOperationTooling> MfgOrderOperationTooling { get; set; }
        public DbSet<MfgOperationMapping> MfgOperationMapping { get; set; }
        public DbSet<MfgOrderOperationLinkedBatch> MfgOrderOperationLinkedBatch { get; set; }
        public DbSet<MfgSAPMapping> MfgSAPMapping { get; set; }

        #region "Packaging Data"
        public DbSet<MfgOrderPackagingInfo> MfgOrderPackagingInfo { get; set; }
        public DbSet<MfgOrderPackagingStructure> MfgOrderPackagingStructure { get; set; }
        public DbSet<MfgOrderSampleType> MfgOrderSampleType { get; set; }
        public DbSet<MfgOrderSampling> MfgOrderSampling { get; set; }

        public DbSet<MfgSampleCrossOrderCount> MfgSampleCrossOrderCount { get; set; }
        public DbSet<MfgPackedLot> MfgPackedLot { get; set; }
        public DbSet<MfgPackedLotBundle> MfgPackedLotBundle { get; set; }
        public DbSet<MfgPackedLotBundleDetail> MfgPackedLotBundleDetail { get; set; }
        public DbSet<MfgPackVariations> MfgPackVariations { get; set; }

        public DbSet<MfgSamplingPlan> MfgSamplingPlan { get; set; }
        public DbSet<MfgSamplingLevelAQL> MfgSamplingLevelAQL { get; set; }
        public DbSet<MfgSamplingMaterialInspectionLevel> MfgSamplingMaterialInspectionLevel { get; set; }
        #endregion

        public DbSet<MfgInboundInterface> MfgInboundInterface { get; set; }
        public DbSet<MfgOutboundInterface> MfgOutboundInterface { get; set; }
        public DbSet<MfgMessagingQueue> MfgMessagingQueue { get; set; }
        public DbSet<MfgInterfaceConfiguration> MfgInterfaceConfiguration { get; set; }
        public DbSet<MfgInterfaceInventoryManage> MfgInterfaceInventoryManage { get; set; }

        public DbSet<MfgExecutionEventInterface> MfgExecutionEventInterface { get; set; }
        public DbSet<MfgExceptionLog> MfgExceptionLog { get; set; }
        public DbSet<MfgSiteConfiguration> MfgSiteConfiguration { get; set; }
        public DbSet<WDTransactionLog> WDTransactionLog { get; set; }
        public DbSet<MfgUniqueIdGenerator> MfgUniqueIdGenerator { get; set; }
        public DbSet<MfgLabelData> MfgLabelData { get; set; }

        public DbSet<MfgEquipmentStatusDefinition> MfgEquipmentStatusDefinition { get; set; }

        public DbSet<MfgEquipmentStatusHistory> MfgEquipmentStatusHistory { get; set; }

        public DbSet<MfgEquipmentStatus> MfgEquipmentStatus { get; set; }

        public DbSet<MfgSite> MfgSite { get; set; }
        public DbSet<MfgLocation> MfgLocation { get; set; }

        public DbSet<WDOrderMixBatch> WDOrderMixBatch { get; set; }
        public DbSet<WDOrderMixBatchBOM> WDOrderMixBatchBOM { get; set; }

        public DbSet<WDOrderMixBatchOperation> WDOrderMixBatchOperation { get; set; }
        public DbSet<MfgShiftSchedule> MfgShiftSchedules { get; set; }


        public DbSet<MfgLanguage> MfgLanguage { get; set; }
        public DbSet<MfgMessageDetail> MfgMessageDetail { get; set; }
        public DbSet<MfgMessage> MfgMessage { get; set; }
        public DbSet<MfgApplicationEvent> MfgApplicationEvent { get; set; }
        public DbSet<MfgApplicationLog> MfgApplicationLog { get; set; }
        public DbSet<MfgCodeDetail> MfgCodeDetail { get; set; }
        public DbSet<MfgApplicationConfiguration> MfgApplicationConfiguration { get; set; }
        public DbSet<MfgStatus> MfgStatus { get; set; }
        public DbSet<MfgProcessType> MfgProcessType { get; set; }

        public DbSet<MfgProcessArea> MfgProcessArea { get; set; }

        public DbSet<MfgShiftGroup> MfgShiftGroup { get; set; }

        public DbSet<MfgShiftCalendar> MfgShiftCalendar { get; set; }

        public DbSet<MfgShiftSettings> MfgShiftSettings { get; set; }

        public DbSet<MfgLineClearanceDetails> MfgLineClearanceDetails { get; set; }

        // Product Master / SAP Plant Storagae Location
        public DbSet<MfgProduct> MfgProduct { get; set; }
        public DbSet<MfgProductQCSample> MfgProductQCSample { get; set; }
        public DbSet<MfgInventory> MfgInventory { get; set; }
        public DbSet<MfgBagInventory> MfgBagInventory { get; set; }
        public DbSet<MfgBatch> MfgBatch { get; set; }
        public DbSet<MfgProductAlternateUOM> MfgProductAlternateUOM { get; set; }
        public DbSet<MfgBatchStatus> MfgBatchStatus { get; set; }
        public DbSet<MfgGhsDetail> MfgGhsDetail { get; set; }
        public DbSet<MfgGhsCharValue> MfgGhsCharValue { get; set; }
        public DbSet<MfgLineCurrentSetup> MfgLineCurrentSetup { get; set; }
        // Added object tables
        public DbSet<MfgObjectClassPropertyValue> MfgObjectClassPropertyValue { get; set; }
        public DbSet<MfgObjectClassProperty> MfgObjectClassProperty { get; set; }
        public DbSet<MfgObjectStateProperty> MfgObjectStateProperty { get; set; }
        public DbSet<MfgObjectClass> MfgObjectClass { get; set; }

        #region Orchestration Generic Execution Structures
        public DbSet<MfgExecutionProcessing> MfgExecutionProcessing { get; set; }
        public DbSet<MfgExecutionConfiguration> MfgExecutionConfiguration { get; set; }
        public DbSet<MfgProcess> MfgProcess { get; set; }
        public DbSet<MfgOperation> MfgOperation { get; set; }
        public DbSet<MfgOperationSubType> MfgOperationSubType { get; set; }
        public DbSet<MfgOperationProcess> MfgOperationProcess { get; set; }
        public DbSet<MfgStage> MfgStage { get; set; }
        public DbSet<MfgProcessStage> MfgProcessStage { get; set; }
        public DbSet<MfgOperationProcessStage> MfgOperationProcessStage { get; set; }
        public DbSet<MfgProcessExecution> MfgProcessExecution { get; set; }
        public DbSet<MfgProcessExecutionDetail> MfgProcessExecutionDetail { get; set; }
        public DbSet<MfgProcessInstruction> MfgProcessInstruction { get; set; }
        public DbSet<MfgProcessInstructionDetail> MfgProcessInstructionDetail { get; set; }
        public DbSet<MfgProcessInstructionCode> MfgProcessInstructionCode { get; set; }

        #endregion Orchestration Generic Execution Structures

        // Label Set Structures
        public DbSet<MfgLabelSet> MfgLabelSet { get; set; }
        public DbSet<MfgLabelDefinition> MfgLabelDefinition { get; set; }
        public DbSet<MfgLabelPrinter> MfgLabelPrinter { get; set; }
        public DbSet<MfgLabelFile> MfgLabelFile { get; set; }
        public DbSet<MfgLabelPrinterType> MfgLabelPrinterType { get; set; }
        public DbSet<MfgLabelSetLabel> MfgLabelSetLabel { get; set; }
        public DbSet<MfgLabelType> MfgLabelType { get; set; }
        public DbSet<MfgLabelProcess> MfgLabelProcess { get; set; }
        public DbSet<MfgLabelText> MfgLabelText { get; set; }
        public DbSet<MfgLabelTextDetail> MfgLabelTextDetail { get; set; }
        public DbSet<MfgLabelPrintDetail> MfgLabelPrintDetail { get; set; }
        public DbSet<MfgOperationLabelPrint> MfgOperationLabelPrint { get; set; }
        // Security Structures
        public DbSet<MfgUser> MfgUser { get; set; }
        public DbSet<MfgUserCredentials> MfgUserCredentials { get; set; }
        public DbSet<MfgUserKey> MfgUserKey { get; set; }
        public DbSet<MfgRole> MfgRole { get; set; }
        public DbSet<MfgUserRole> MfgUserRole { get; set; }
        public DbSet<MfgAuthorization> MfgAuthorization { get; set; }
        public DbSet<MfgRoleAuthorization> MfgRoleAuthorization { get; set; }

        // Master Data Structures
        public DbSet<MfgEquipment> MfgEquipment { get; set; }
        public DbSet<MfgScale> MfgScale { get; set; }
        public DbSet<MfgScaleLibrary> MfgScaleLibrary { get; set; }
        public DbSet<MfgState> MfgState { get; set; }
        public DbSet<MfgStateDiagram> MfgStateDiagram { get; set; }
        public DbSet<MfgStateOption> MfgStateOption { get; set; }
        public DbSet<MfgProductionUnit> MfgProductionUnit { get; set; }
        public DbSet<MfgStorageUnitType> MfgStorageUnitType { get; set; }
        public DbSet<MfgProductionUnitOperation> MfgProductionUnitOperation { get; set; }
        public DbSet<MfgStateChangeHistory> MfgStateChangeHistory { get; set; }
        public DbSet<MfgProductionUnitMaterial> MfgProductionUnitMaterial { get; set; }
        public DbSet<MfgStorageUnit> MfgStorageUnit { get; set; }
        public DbSet<MfgInventoryTransactionHistory> MfgInventoryTransactionHistory { get; set; }
        public DbSet<MfgProductionUnitStorageUnit> MfgProductionUnitStorageUnit { get; set; }
        public DbSet<MfgProductionUnitEquipment> MfgProductionUnitEquipment { get; set; }
        public DbSet<MfgProductionUnitValidatedTool> MfgProductionUnitValidatedTool { get; set; }
        public DbSet<MfgStorageUnitOperation> MfgStorageUnitOperation { get; set; }
        public DbSet<MfgProductionUnitInventory> MfgProductionUnitInventory { get; set; }
        public DbSet<MfgProductionUnitPrinter> MfgProductionUnitPrinter { get; set; }
        public DbSet<MfgStateChangeQueue> MfgStateChangeQueue { get; set; }

        public DbSet<MfgStateAction> MfgStateAction { get; set; }
        public DbSet<MfgScrapCode> MfgScrapCode { get; set; }
        public DbSet<MfgScrapCodeDescription> MfgScrapCodeDescription { get; set; }
        public DbSet<MfgMaterialType> MfgMaterialType { get; set; }
        public DbSet<MfgMaterialMapping> MfgMaterialMapping { get; set; }

        public DbSet<MfgProductionUnitOperationTool> MfgProductionUnitOperationTool { get; set; }
        public DbSet<MfgProductionUnitTool> MfgProductionUnitTool { get; set; }
        public DbSet<MfgProductionUnitScheduleCategoryShift> MfgProductionUnitScheduleCategoryShift { get; set; }
        public DbSet<MfgProductPackagingTemplate> MfgProductPackagingTemplate { get; set; }
        public DbSet<MfgProductPackagingDetail> MfgProductPackagingDetail { get; set; }
        public DbSet<MfgProductPackaging> MfgProductPackaging { get; set; }

        public DbSet<MfgInventoryStorageDetail> MfgInventoryStorageDetail { get; set; }
        public DbSet<MfgInventoryStorageType> MfgInventoryStorageType { get; set; }
        public DbSet<MfgInspectionLot> MfgInspectionLot { get; set; }

        public DbSet<MfgLine> MfgLine { get; set; }
        public DbSet<MfgRoom> MfgRoom { get; set; }
        public DbSet<MfgOperationTimeDefaults> MfgOperationTimeDefaults { get; set; }

        // Notification Data
        public DbSet<MfgNotification> MfgNotification { get; set; }
        public DbSet<MfgNotificationHistory> MfgNotificationHistory { get; set; }
        public DbSet<CppTags> CppTags { get; set; }
        public DbSet<MfgSecondaryAuthTransactionDetail> MfgSecondaryAuthTransactionDetail { get; set; }

        public DbSet<MfgDimensionLineStatistics> MfgDimensionLineStatistics { get; set; }

        public DbSet<MfgWorkTicket> MfgWorkTicket { get; set; }
        public DbSet<MfgWorkTicketOrderOperation> MfgWorkTicketOrderOperation { get; set; }
        public DbSet<MfgWorkTicketTooling> MfgWorkTicketTooling { get; set; }

        public DbSet<MfgWorkTicketAdjustment> MfgWorkTicketAdjustment { get; set; }
        public DbSet<MfgOrderExtended> MfgOrderExtended { get; set; }

        //public DbSet<MfgProductionUnitScheduleCategoryShift> MfgProductionUnitScheduleCategoryShift { get; set; }
        // Connectivity Team required table(s) info
        #region "Connectivity models"

        public DbSet<ConUDCYaml> ConUDCYaml { get; set; }
        public DbSet<ConNFCTag> ConNFCTag { get; set; }
        public DbSet<ConnEquipmentDefinition> ConnEquipmentDefinition { get; set; }
        public DbSet<ConnOPCServerConfiguration> ConnOPCServerConfiguration { get; set; }
        public DbSet<ConnectivityPLCTypes> ConnectivityPLCTypes { get; set; }
        public DbSet<ConnectivityTagSettingItemsDetail> ConnectivityTagSettingItemsDetail { get; set; }
        public DbSet<ConnectivityKepwareTagDataTypeList> ConnectivityKepwareTagDataTypeList { get; set; }
        public DbSet<ConnectivityKepwareArchiveHeader> ConnectivityKepwareArchiveHeader { get; set; }
        public DbSet<ConnKepwareArchiveComponentProperties> ConnKepwareArchiveComponentProperties { get; set; }
        public DbSet<ConnectivityHumanReadable> ConnectivityHumanReadable { get; set; }
        public DbSet<ConnectivityEquipmentInfo> ConnectivityEquipmentInfo { get; set; }
        #endregion

        #region DeviceInterface
        public DbSet<MfgInboundDeviceInterface> MfgInboundDeviceInterface { get; set; }
        public DbSet<MfgOutboundDeviceInterface> MfgOutboundDeviceInterface { get; set; }
        public DbSet<MfgCycleDetail> MfgCycleDetail { get; set; }
        public DbSet<MfgControlKey> MfgControlKey { get; set; }

        // Serial Devices for RECON interface
        public DbSet<MfgSerialDevice> MfgSerialDevice { get; set; }
        public DbSet<MfgDeviceResultDetails> MfgDeviceResultDetails { get; set; }

        // AGV related sets for R7S Interface
        public DbSet<MfgAgvBatchStatus> MfgAgvBatchStatus { get; set; }
        public DbSet<MfgAgvCheckResponse> MfgAgvCheckResponse { get; set; }
        public DbSet<MfgAgvCheckRequest> MfgAgvCheckRequest { get; set; }
        public DbSet<MfgAgvConfiguration> MfgAgvConfiguration { get; set; }
        public DbSet<MfgAgvCurrentState> MfgAgvCurrentState { get; set; }
        public DbSet<MfgAgvIMPLocationTag> MfgAgvIMPLocationTag { get; set; }
        public DbSet<MfgAgvResponse> MfgAgvResponse { get; set; }
        public DbSet<MfgAgvSequence> MfgAgvSequence { get; set; }
        public DbSet<MfgAgvToteInformation> MfgAgvToteInformation { get; set; }
        public DbSet<MfgAgvTransactions> MfgAgvTransactions { get; set; }
        public DbSet<MfgAgvWorkCenterOrderSetTag> MfgAgvWorkCenterOrderSetTag { get; set; }
        public DbSet<MfgAgvWorkCenterToImpLocation> MfgAgvWorkCenterToImpLocation { get; set; }

        #endregion DeviceInterface 

        #region ProcessTransaction
        public DbSet<MfgWIPBatch> MfgWIPBatch { get; set; }
        public DbSet<MfgInspectionDetail> MfgInspectionDetail { get; set; }
        #endregion ProcessTransaction

        #region RuleEngine
        public DbSet<MfgRule> MfgRule { get; set; }
        public DbSet<MfgRuleSchedule> MfgRuleSchedule { get; set; }
        public DbSet<MfgRuleImpact> MfgRuleImpact { get; set; }
        public DbSet<MfgRuleExecutionDetail> MfgRuleExecutionDetail { get; set; }
        public DbSet<MfgRuleConfiguration> MfgRuleConfiguration { get; set; }
        public DbSet<MfgRuleAction> MfgRuleAction { get; set; }
        public DbSet<MfgRuleActionMapping> MfgRuleActionMapping { get; set; }
        public DbSet<MfgEntity> MfgEntity { get; set; }

        public DbSet<MfgEntityInformation> MfgEntityInformation { get; set; }

        public DbSet<MfgProductionUnitUser> MfgProductionUnitUser { get; set; }
        #endregion RuleEngine

        #region "Tooling"
        public DbSet<MfgTool> MfgTool { get; set; }
        public DbSet<MfgToolProduct> MfgToolProduct { get; set; }
        public DbSet<MfgToolType> MfgToolType { get; set; }
        public DbSet<MfgToolGroup> MfgToolGroup { get; set; }

        #endregion

        #region Instruction
        public DbSet<MfgInstruction> MfgInstruction { get; set; }
        public DbSet<MfgInstructionAuth> MfgInstructionAuth { get; set; }
        public DbSet<MfgInstructionGroup> MfgInstructionGroup { get; set; }
        public DbSet<MfgInstructionGroupMapping> MfgInstructionGroupMapping { get; set; }
        public DbSet<MfgInstructionGroupMappingDetail> MfgInstructionGroupMappingDetail { get; set; }
        public DbSet<MfgInstructionImage> MfgInstructionImage { get; set; }
        public DbSet<MfgInstructionMedia> MfgInstructionMedia { get; set; }
        public DbSet<MfgInstructionDetail> MfgInstructionsDetail { get; set; }
        public DbSet<MfgProductionUnitInstructionGroup> MfgProductionUnitInstructionGroup { get; set; }
        public DbSet<MfgStateActionInstructions> MfgStateActionInstructions { get; set; }
        public DbSet<MfgStateActionInstructionTransaction> MfgStateActionInstructionTransaction { get; set; }
        public DbSet<MfgStateActionInstructionTransactionDetail> MfgStateActionInstructionTransactionDetail { get; set; }
        public DbSet<MfgInstructionDocument> MfgInstructionDocument { get; set; }
        #endregion Instruction

        #region Activity
        public DbSet<MfgActivity> MfgActivity { get; set; }
        public DbSet<MfgActivityDetail> MfgActivityDetail { get; set; }
        public DbSet<MfgActivityMedia> MfgActivityMedia { get; set; }
        #endregion Activity

        #region DLC Models 
        public DbSet<DlcProductionUnitState> DlcProductionUnitState { get; set; }
        #endregion DLC Models 

        #region History Models
        public DbSet<MfgProcessExecutionDetailHistory> MfgProcessExecutionDetailHistory { get; set; }
        public DbSet<MfgProductionUnitOperationToolHistory> MfgProductionUnitOperationToolHistory { get; set; }
        public DbSet<MfgProductionUnitToolHistory> MfgProductionUnitToolHistory { get; set; }
        public DbSet<MfgProductionUnitInventoryHistory> MfgProductionUnitInventoryHistory { get; set; }
        public DbSet<MfgBatchHistory> MfgBatchHistory { get; set; }
        public DbSet<MfgInventoryHistory> MfgInventoryHistory { get; set; }
        public DbSet<MfgSerialDeviceHistory> MfgSerialDeviceHistory { get; set; }
        public DbSet<DlcProductionUnitStateHistory> DlcProductionUnitStateHistory { get; set; }
        #endregion History Models

        #region MfgCart
        public DbSet<MfgCart> MfgCart { get; set; }

        public DbSet<MfgCartBatchDetail> MfgCartBatchDetail { get; set; }
        public DbSet<MfgZone> MfgZone { get; set; }
        public DbSet<MfgCell> MfgCell { get; set; }
        public DbSet<MfgZoneCellMapping> MfgZoneCellMapping { get; set; }
        #endregion

        #region AdditionalInformation
        public DbSet<MfgOperationMetaData> MfgOperationMetaData { get; set; }

        public DbSet<MfgOperationMetaDataDetail> MfgOperationMetaDataDetail { get; set; }
        public DbSet<MfgScheduleOrder> MfgScheduleOrder { get; set; }
        public DbSet<MfgScheduleCompaign> MfgScheduleCompaign { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entityMethod = typeof(ModelBuilder).GetMethod("Entity", new Type[] { });
            foreach (Type item in MfgCommon.GetTypesInNamespace())
            {
                entityMethod.MakeGenericMethod(item).Invoke(modelBuilder, new object[] { });
            }

            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.SetTableName(entityType.DisplayName());
            }

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            #region Index
            //Table:  ManufacturingOrder
            modelBuilder.Entity<MfgOrder>()
            .HasIndex(p => new { p.PlantId, p.ProcessOrder, p.BatchNumber })
            .IsUnique();

            modelBuilder.Entity<MfgOrder>()
            .HasIndex(p => new { p.ProcessOrder, p.BatchNumber })
            .IsUnique();

            //Table:  OrderComponent
            modelBuilder.Entity<MfgOrderComponent>()
            .HasIndex(p => new { p.OperationNumber, p.BOMSequence });

            //Table:  OrderOperation
            modelBuilder.Entity<MfgOrderOperation>()
            .HasIndex(p => new { p.OperationNumber });

            modelBuilder.Entity<MfgOrderType>()
                .HasIndex(p => new { p.OrderType });

            modelBuilder.Entity<MfgProduct>()
              .HasIndex(p => new { p.MaterialNumber })
              .IsUnique();

            //Table:  MfgEquipmentStatusHistory
            modelBuilder.Entity<MfgEquipmentStatusHistory>()
            .HasIndex(p => new { p.MfgEquipmentId, p.RecordID })
            .IsUnique();

            //Table:  MfgEquipmentStatus
            modelBuilder.Entity<MfgEquipmentStatus>()
           .HasIndex(p => new { p.MfgEquipmentId, p.MfgEquipmentStatusDefinitionId })
           .IsUnique();

            //Table:  MfgEquipmentStatusDefinition
            modelBuilder.Entity<MfgEquipmentStatusDefinition>()
           .HasIndex(p => new { p.PlantID, p.ApplicationCode, p.StatusCode })
           .IsUnique();

            modelBuilder.Entity<MfgEntity>()
                .HasIndex(p => new { p.EntityName, p.EntityProperty })
                .IsUnique();

            modelBuilder.Entity<MfgEntityInformation>()
                .HasIndex(p => new { p.MfgEntityId, p.MfgLanguageId })
                .IsUnique();

            modelBuilder.Entity<MfgProductionUnitUser>()
                .HasIndex(p => new { p.MfgProductionUnitId, p.MfgUserId })
                .IsUnique();

            //Table:  MfgShiftSchedule
            modelBuilder.Entity<MfgShiftSchedule>()
                .HasIndex(p => new { p.PlantID, p.ScheduleShift, p.StartTime, p.EndTime, p.MfgProcessAreaId })
                .IsUnique();

            //Table:  MfgShiftCalendar
            modelBuilder.Entity<MfgShiftCalendar>()
                .HasIndex(p => new { p.PlantID, p.CalendarDate, p.CalendarShift, p.IsScheduledPeriod, p.MfgShiftScheduleId })
                .IsUnique();

            //Table:  MfgShiftGroup
            modelBuilder.Entity<MfgShiftGroup>()
                .HasIndex(p => new { p.GroupName, p.GroupDescription })
                .IsUnique();

            //Table:  MfgShiftSettings
            modelBuilder.Entity<MfgShiftSettings>()
                .HasIndex(p => new { p.PlantID, p.DateNameActual, p.StartTime, p.ShiftArea })
                .IsUnique();

            //Table:  MfgProcessArea
            modelBuilder.Entity<MfgProcessArea>()
                .HasIndex(p => new { p.ProcessAreaName, p.ProcessAreaDescription, p.IsSiteDefault, p.PlantID })
                .IsUnique();

            modelBuilder.Entity<MfgOrderOperationCycleSetting>()
            .HasIndex(p => new { p.MfgOrderOperationId })
            .IsUnique();

            modelBuilder.Entity<MfgOrderOperationTooling>()
            .HasIndex(p => new { p.MfgOrderOperationId })
            .IsUnique();

            modelBuilder.Entity<MfgOrderOperationTooling>()
                .HasIndex(p => new { p.MfgToolTypeId, p.MfgOrderOperationId, p.MfgToolGroupName })
                .IsUnique();

            modelBuilder.Entity<MfgOrderPackagingStructure>()
            .HasIndex(b => new { b.MfgOrderId, b.MfgOrderSamplingId, b.PackSequence, b.Layer })
            .IsUnique();

            modelBuilder.Entity<MfgOrderPackagingInfo>()
            .HasIndex(b => new { b.MfgOrderId })
            .IsUnique();

            modelBuilder.Entity<MfgOrder>()
            .HasOne(b => b.MfgOrderPackagingInfo)
            .WithOne(i => i.MfgOrder)
            .HasForeignKey<MfgOrderPackagingInfo>(b => b.MfgOrderId)
            .IsRequired(false);

            modelBuilder.Entity<MfgOrderSampleType>()
            .HasIndex(b => new { b.SampleTypeCode })
            .IsUnique();

            modelBuilder.Entity<MfgOrderSampling>()
            .HasIndex(b => new { b.MfgOrderOperationId });

            modelBuilder.Entity<MfgOrderOperationLinkedBatch>()
            .HasIndex(b => new { b.MfgOrderOperationId, b.MfgBatchId })
            .IsUnique();

            modelBuilder.Entity<MfgOrderOperationLinkedBatch>()
            .HasIndex(b => new { b.MfgOrderOperationId, b.MfgBatchId })
            .IncludeProperties(b => new { b.MfgOrderId, b.LinkedStatus })
            .IsUnique();

            modelBuilder.Entity<MfgOrderOperationLinkedBatch>()
            .HasIndex(b => new { b.LinkedStatus, b.MfgOrderOperationId, b.MfgBatchId })
            .IncludeProperties(b => new { b.MfgOrderId });

            modelBuilder.Entity<MfgSampling>()
            .HasIndex(b => b.SampleName)
            .IsUnique();

            modelBuilder.Entity<MfgOperationMapping>()
                .HasIndex(b => b.ErpCode)
                .IsUnique();

            modelBuilder.Entity<MfgPackVariations>()
                .HasIndex(x => new { x.TableName, x.PropertyName, x.VariationNumber, x.PropertyValue })
                .IsUnique();

            modelBuilder.Entity<MfgPackedLot>()
                .Property(b => b.IsOverpackSupervisorAuth)
                .HasDefaultValue(false);

            modelBuilder.Entity<MfgStorageUnitType>()
                .Property(b => b.IsAvailableForAncillary)
                .HasDefaultValue(false);

            modelBuilder.Entity<MfgUniqueIdGenerator>()
            .HasIndex(b => new { b.Code, b.PlantId })
            .IsUnique();

            modelBuilder.Entity<MfgProductionUnitOperationTool>()
                .HasIndex(b => new { b.MfgProductionUnitOperationId, b.MfgToolTypeId })
                .IsUnique();

            // Tool can only be used in one work center at any time. 
            modelBuilder.Entity<MfgProductionUnitTool>()
                .HasIndex(b => new { b.MfgToolId })
                .IsUnique();

            modelBuilder.Entity<MfgProductionUnitTool>()
                .HasIndex(b => new { b.MfgProductionUnitId, b.MfgEquipmentId, b.MfgEquipmentPositionId, b.MfgToolGroupId, b.MfgToolId })
                .IsUnique();

            modelBuilder.Entity<MfgProductPackaging>()
                .HasIndex(b => new { b.MfgProductId, b.ShipTo })
                .IncludeProperties(b => new { b.Id, b.MfgProductPackagingTemplateId })
                .IsUnique();

            modelBuilder.Entity<MfgProductPackagingTemplate>()
                .HasIndex(b => new { b.PackagingTemplateCode })
                .IsUnique();

            modelBuilder.Entity<MfgProductPackagingDetail>()
                .HasIndex(b => new { b.MfgProductPackagingTemplateId, b.LayerNumber })
                .IsUnique();

            modelBuilder.Entity<MfgInterfaceInventoryManage>()
                .HasIndex(b => new { b.BatchNumber, b.Location, b.StorageBin, b.StckType });

            modelBuilder.Entity<MfgInboundInterface>()
                .HasIndex(b => new { b.QueueId });

            modelBuilder.Entity<MfgOutboundInterface>()
                .HasIndex(b => new { b.QueueId });

            modelBuilder.Entity<MfgControlKey>()
                .HasIndex(b => new { b.PlantId, b.ControlKey })
                .IsUnique();

            modelBuilder.Entity<MfgSamplingPlan>()
                .HasIndex(b => new { b.SamplingSizeCode, b.AQLPercentage })
                .IsUnique();

            modelBuilder.Entity<MfgSamplingLevelAQL>()
                .HasIndex(b => new { b.LotSizeMin, b.LotSizeMax })
                .IsUnique();

            modelBuilder.Entity<MfgSamplingMaterialInspectionLevel>()
                .HasIndex(b => new { b.MaterialNumber })
                .IsUnique();

            #region Generic Execution Models
            modelBuilder.Entity<MfgExecutionConfiguration>()
                .HasIndex(p => new { p.PlantId, p.TransactionType })
                .IsUnique();

            #endregion

            #region Object Definitions
            modelBuilder.Entity<MfgObjectClass>()
                .HasIndex(p => new { p.ClassName })
                .IsUnique();

            modelBuilder.Entity<MfgObjectClassProperty>()
                .HasIndex(p => new { p.PropertyName });
            #endregion

            #region Date/Time Shift
            modelBuilder.Entity<MfgProcessArea>()
                .Property(b => b.IsSiteDefault)
                .HasDefaultValue(false);

            modelBuilder.Entity<MfgShiftCalendar>()
                .Property(b => b.CalendarDate)
                .HasDefaultValueSql("CONVERT(date, getdate())");

            modelBuilder.Entity<MfgShiftCalendar>()
                .Property(b => b.IsScheduledPeriod)
                .HasDefaultValue(true);
            #endregion

            #region Security


            modelBuilder.Entity<MfgUser>()
                .HasIndex(p => new { p.UserName })
                .IsUnique();

            modelBuilder.Entity<MfgUser>()
                .HasIndex(p => new { p.ERPUserID })
                .IsUnique();

            modelBuilder.Entity<MfgUserRole>()
                .HasIndex(p => new { p.MfgUserId, p.MfgRoleId })
                .IsUnique();

            modelBuilder.Entity<MfgRole>()
                .HasIndex(p => new { p.RoleName })
                .IsUnique();

            modelBuilder.Entity<MfgRoleAuthorization>()
                .HasIndex(p => new { p.MfgRoleId, p.MfgAuthorizationId })
                .IsUnique();

            modelBuilder.Entity<MfgAuthorization>()
                .HasIndex(p => new { p.AuthorizationCode })
                .IsUnique();

            #endregion

            #region "Master Data"

            modelBuilder.Entity<MfgEquipment>()
            .HasIndex(p => new { p.EquipmentName })
            .IsUnique();

            modelBuilder.Entity<MfgEquipment>()
            .HasIndex(p => new { p.Classification });

            modelBuilder.Entity<MfgStorageUnit>()
            .HasIndex(p => new { p.SUName })
            .IsUnique();

            modelBuilder.Entity<MfgProductionUnit>()
            .HasIndex(p => new { p.PUName })
            .IsUnique();

            modelBuilder.Entity<MfgProductionUnitMaterial>()
                .HasIndex(p => new { p.MaterialNumber, p.ResourceName })
                .IsUnique();

            modelBuilder.Entity<MfgProductionUnitMaterial>()
                .HasIndex(p => new { p.MaterialNumber, p.ResourceName, p.ERPOperationName })
                .IsUnique();

            modelBuilder.Entity<MfgGhsDetail>()
                .HasIndex(p => new { p.GhsCharName })
                .IsUnique();

            modelBuilder.Entity<MfgGhsCharValue>()
                .HasIndex(p => new { p.MfgGhsDetailId });

            modelBuilder.Entity<MfgLine>()
            .HasIndex(p => new { p.PlantId, p.LineName })
            .IsUnique();

            modelBuilder.Entity<MfgLine>()
            .HasIndex(p => new { p.PlantId, p.LineCode })
            .IsUnique();

            modelBuilder.Entity<MfgRoom>()
            .HasIndex(p => new { p.PlantId, p.RoomName })
            .IsUnique();

            modelBuilder.Entity<MfgRoom>()
            .HasIndex(p => new { p.PlantId, p.RoomCode })
            .IsUnique();


            modelBuilder.Entity<MfgLineCurrentSetup>()
                .HasIndex(p => new { p.MfgLineId })
                .IsUnique();
            #endregion

            #region "RuleEngine"
            modelBuilder.Entity<MfgRuleImpact>().HasIndex(b => new { b.MfgRuleId });
            modelBuilder.Entity<MfgRuleSchedule>().HasIndex(b => new { b.MfgRuleImpactId });
            modelBuilder.Entity<MfgRuleConfiguration>().HasIndex(b => new { b.MfgRuleImpactId });
            modelBuilder.Entity<MfgRuleActionMapping>().HasIndex(b => new { b.MfgRuleImpactId });
            #endregion "RuleEngine"

            #region "Orchestration"
            modelBuilder.Entity<MfgProcessExecutionDetail>().HasIndex(b => new { b.ProcessOrder });
            modelBuilder.Entity<MfgProcessExecutionDetail>().HasIndex(b => new { b.TransactionReferenceId });
            modelBuilder.Entity<MfgProcessExecutionDetail>().HasIndex(b => new { b.MfgOperationProcessStageId });
            modelBuilder.Entity<MfgProcessExecutionDetail>().HasIndex(b => new { b.TransactionType });
            modelBuilder.Entity<MfgProcessExecutionDetail>().HasIndex(b => new { b.PlantId });
            modelBuilder.Entity<MfgProcessExecutionDetail>().HasIndex(b => new { b.MfgOrderId });
            #endregion "Orchestration"

            modelBuilder.Entity<MfgBatchStatus>()
                .HasIndex(p => new { p.StatusCode })
                .IsUnique();

            modelBuilder.Entity<MfgScaleLibrary>()
                .HasIndex(p => new { p.LibraryType })
                .IsUnique();

            modelBuilder.Entity<MfgScale>()
                .HasIndex(p => new { p.ScaleName })
                .IsUnique();

            modelBuilder.Entity<MfgMaterialType>()
                .HasIndex(p => new { p.MaterialTypeCode })
                .IsUnique();

            modelBuilder.Entity<MfgMaterialMapping>()
                .HasIndex(p => new { p.PlantId, p.MaterialNumber })
                .IsUnique();

            modelBuilder.Entity<MfgMaterialMapping>()
                .HasIndex(p => new { p.PlantId, p.MapNumber })
                .IsUnique();

            modelBuilder.Entity<MfgBatch>()
                .HasIndex(p => new { p.BatchNumber })
                .IncludeProperties(p => new { p.Id, p.NonBatchId })
                .HasFilter("[NonBatchId] IS NULL")
                .IsUnique();

            modelBuilder.Entity<MfgBatch>()
                .HasIndex(p => new { p.MfgProductId })
                .IncludeProperties(p => new { p.NonBatchId, p.Id })
                .HasFilter("[NonBatchId] IS NOT NULL")
                .IsUnique();

            modelBuilder.Entity<MfgInventory>()
                .HasIndex(p => new
                {
                    p.PlantId,
                    p.MfgBatchId,
                    p.MfgLocationId,
                    p.MfgInventoryStatusId,
                    p.MfgInventoryStorageTypeId,
                    p.StorageBin,
                    p.HandlingUnit
                })
                .IsUnique();

            modelBuilder.Entity<MfgInventory>()
                .HasIndex(p => new
                {
                    p.MfgLocationId,
                    p.MfgInventoryStorageTypeId,
                    p.StorageBin,
                    p.HandlingUnit,
                    p.MfgInventoryStatusId
                });

            modelBuilder.Entity<MfgLocation>()
                .HasIndex(p => new { p.PlantId, p.LocationName })
                .IsUnique();

            modelBuilder.Entity<MfgInventory>()
                .HasIndex(p => p.StorageBin);

            modelBuilder.Entity<MfgInventory>()
                .HasIndex(p => p.HandlingUnit);

            modelBuilder.Entity<MfgInventoryStorageType>()
                .HasIndex(p => p.InvStorageTypeCode)
                .IsUnique();


            modelBuilder.Entity<MfgInspectionLot>()
                .HasIndex(p => p.MfgBatchId);

            modelBuilder.Entity<MfgInspectionLot>()
                .HasIndex(p => p.MfgOrderId);

            #region "AGV Interface Indices"

            modelBuilder.Entity<MfgAgvBatchStatus>()
                .HasIndex(p => new { p.PlantId, p.BatchNumber })
                .IsUnique();

            modelBuilder.Entity<MfgAgvCheckRequest>()
                .HasIndex(p => p.IMPRequestType);

            modelBuilder.Entity<MfgAgvCheckResponse>()
                .HasIndex(p => new { p.CheckRequestId, p.CheckResult })
                .IsUnique();

            modelBuilder.Entity<MfgAgvCurrentState>()
                .HasIndex(p => new { p.WorkCenter, p.PlantId })
                .IsUnique();

            modelBuilder.Entity<MfgAgvResponse>()
                .HasIndex(p => p.CreatedDateTime)
                .IncludeProperties(p => new { p.ProcessingState, p.Id });

            modelBuilder.Entity<MfgAgvToteInformation>()
                .HasIndex(p => p.LabelData);
            modelBuilder.Entity<MfgAgvToteInformation>()
                .HasIndex(p => p.ToteId)
                .IsUnique();

            modelBuilder.Entity<MfgAgvTransactions>()
                .HasIndex(p => new
                {
                    p.CreatedDateTime,
                    p.IMP_Transaction_Number_VALUE,
                    p.IMP_Number,
                    p.IMP_Request_Type_VALUE
                });

            modelBuilder.Entity<MfgAgvWorkCenterToImpLocation>()
                .HasIndex(p => p.ImpLocation)
                .IsUnique();

            #endregion "AGV Interface Indices"

            #region "Label Table Indexes"
            modelBuilder.Entity<MfgLabelSet>()
                .HasIndex(p => new { p.SetName })
                .IsUnique();

            modelBuilder.Entity<MfgLabelDefinition>()
                .HasIndex(p => new { p.LabelName, p.MfgLabelTypeId })
                .IsUnique();

            modelBuilder.Entity<MfgLabelPrinter>()
                .HasIndex(p => new { p.PrinterName })
                .IsUnique();

            modelBuilder.Entity<MfgLabelFile>()
                .HasIndex(p => new { p.LabelFileName, p.MfgLabelDefinitionId, p.MfgLabelPrinterTypeId })
                .IsUnique();

            modelBuilder.Entity<MfgLabelPrinterType>()
                .HasIndex(p => new { p.PrinterType })
                .IsUnique();

            modelBuilder.Entity<MfgLabelSetLabel>()
                .HasIndex(p => new { p.MfgLabelSetId, p.LabelPrintSequence, p.MfgLabelDefinitionId })
                .IsUnique();

            modelBuilder.Entity<MfgLabelSetLabel>()
                .HasIndex(p => new { p.MfgLabelSetId, p.LabelPrintSequence, p.MfgLabelDefinitionId })
                .IsUnique();
            #endregion

            #region "Tooling Indexes"

            modelBuilder.Entity<MfgTool>()
                .HasIndex(p => new { p.ToolNumber })
                .IsUnique();

            modelBuilder.Entity<MfgTool>()
                 .HasIndex(p => new { p.ToolNumber })
                 .IsUnique();

            modelBuilder.Entity<MfgTool>()
                 .HasIndex(p => new { p.MfgToolTypeId, p.ToolNumber })
                 .IsUnique();

            modelBuilder.Entity<MfgToolType>()
                .HasIndex(p => new { p.ToolType })
                .IsUnique();

            modelBuilder.Entity<MfgToolType>()
                .HasIndex(p => new { p.ToolTypeOperation, p.ToolType });

            modelBuilder.Entity<MfgToolProduct>()
                .HasIndex(p => new { p.MfgToolId, p.MfgProductId })
                .IsUnique();

            modelBuilder.Entity<MfgToolGroup>()
                .HasIndex(p => new { p.MfgToolId, p.ToolGroup })
                .IsUnique();
            modelBuilder.Entity<MfgScrapCodeDescription>()
                .HasIndex(p => new { p.MfgScrapCodeId, p.MfgLanguageId })
                .IsUnique();
            #endregion

            #region "Packaging Indexes"

            modelBuilder.Entity<MfgPackedLot>()
                .HasIndex(p => new { p.LotNumber })
                .IsUnique();

            modelBuilder.Entity<MfgPackedLot>()
                .HasIndex(p => new { p.MfgOrderId, p.LotNumber })
                .IsUnique();

            modelBuilder.Entity<MfgPackedLotBundle>()
                .HasIndex(p => new { p.MfgPackedLotId });

            modelBuilder.Entity<MfgPackedLotBundle>()
                .HasIndex(p => new { p.MfgPackedLotId, p.HandlingUnitNumber })
                .IsUnique();

            modelBuilder.Entity<MfgPackedLotBundle>()
                .HasIndex(p => new { p.HandlingUnitNumber })
                .IsUnique();

            modelBuilder.Entity<MfgPackedLotBundle>()
                .HasIndex(p => new { p.PackedInMfgPackedLotBundleID, p.BundleID })
                .IsUnique();


            #endregion

            #region MfgCart Index
            modelBuilder.Entity<MfgCart>()
            .HasIndex(p => new { p.CartIdentifier })
            .IsUnique();
            #endregion

            #endregion Index

            #region Default Constraint
            //Table : MfgOrder
            modelBuilder.Entity<MfgOrder>()
            .Property(b => b.IsReleased)
            .HasDefaultValue(false);

            //Table:  EquipmentStatus
            modelBuilder.Entity<MfgEquipmentStatusHistory>()
            .Property(b => b.StatusStart)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<MfgEquipmentStatusHistory>()
            .Property(b => b.RecordID)
            .HasDefaultValueSql("newId()");

            //Table:  EquipmentStatusCur
            modelBuilder.Entity<MfgEquipmentStatus>()
            .Property(b => b.StatusStart)
            .HasDefaultValueSql("getdate()");

            //Table:  EquipmentStatusDef
            modelBuilder.Entity<MfgEquipmentStatusDefinition>()
            .Property(b => b.PriviledgeRequired)
            .HasDefaultValue(false);

            modelBuilder.Entity<MfgEquipmentStatusDefinition>()
            .Property(b => b.PriviledgeChangesUser)
            .HasDefaultValue(true);

            modelBuilder.Entity<MfgShiftSchedule>()
            .Property(b => b.StartDateDifferential)
            .HasDefaultValue(0);

            modelBuilder.Entity<MfgShiftSchedule>()
           .Property(b => b.EndDateDifferential)
           .HasDefaultValue(0);

            modelBuilder.Entity<MfgApplicationEvent>()
            .HasIndex(p => new { p.EventCode })
            .IsUnique();

            modelBuilder.Entity<MfgOrder>()
            .Property(b => b.IsReleased)
            .HasDefaultValue(false);

            modelBuilder.Entity<MfgOperationProcess>()
            .Property(b => b.ConcurrencyWithPrior)
            .HasDefaultValue(false);

            modelBuilder.Entity<MfgOperationProcessStage>()
            .Property(b => b.StageConcurrencyWithNext)
            .HasDefaultValue(false);

            modelBuilder.Entity<MfgOperationProcessStage>()
            .Property(b => b.ProcessConcurrencyWithNext)
            .HasDefaultValue(false);

            modelBuilder.Entity<MfgProcessStage>()
            .Property(b => b.ConcurrencyWithPrior)
            .HasDefaultValue(false);

            modelBuilder.Entity<WDOrderMixBatchBOM>()
           .Property(b => b.IsVerified)
           .HasDefaultValue(false);

            modelBuilder.Entity<MfgOrderPackagingStructure>()
                .Property(b => b.PreScanBag)
                .HasDefaultValue(false);

            modelBuilder.Entity<MfgStateChangeQueue>()
           .Property(b => b.RequestStatus)
           .HasDefaultValue(0);

            modelBuilder.Entity<MfgStateChangeQueue>()
           .Property(b => b.Priority)
           .HasDefaultValue(2);

            modelBuilder.Entity<MfgProductionUnit>()
                .Property(x => x.PlantManufacturingSequence)
                .HasDefaultValue(1);

            modelBuilder.Entity<MfgProductionUnitOperation>()
                .Property(x => x.PositionOrderLimit)
                .HasDefaultValue(1);

            modelBuilder.Entity<MfgProductionUnitOperation>()
                .Property(x => x.ProductionUnitOrderLimit)
                .HasDefaultValue(1);

            #endregion Default Contraint

            // Handle of Identity Column Update (Fix issue with PUT and Identity column)
            #region "Identity Column Setting for UPDATE/PUT"
            modelBuilder.Entity<MfgInboundInterface>()
                .Property(p => p.TransactionSequence)
                .UseIdentityColumn()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<MfgOutboundInterface>()
                .Property(p => p.TransactionSequence)
                .UseIdentityColumn()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<MfgMessagingQueue>()
                .Property(p => p.TransactionSequence)
                .UseIdentityColumn()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<MfgExecutionEventInterface>()
                .Property(p => p.TransactionSequence)
                .UseIdentityColumn()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<MfgInboundDeviceInterface>()
                .Property(p => p.TransactionSequence)
                .UseIdentityColumn()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<MfgOutboundDeviceInterface>()
                .Property(p => p.TransactionSequence)
                .UseIdentityColumn()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<MfgUniqueIdGenerator>()
                .Property(p => p.UniqueId)
                .UseIdentityColumn()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            #endregion

            #region "Index over log files and transaction data"

            modelBuilder.Entity<MfgInboundInterface>()
                    .HasIndex(b => new { b.CreatedDateTime, b.Id });

            modelBuilder.Entity<MfgOutboundInterface>()
                    .HasIndex(b => new { b.CreatedDateTime, b.Id });

            modelBuilder.Entity<MfgInboundDeviceInterface>()
                    .HasIndex(b => new { b.CreatedDateTime, b.Id });

            modelBuilder.Entity<MfgOutboundDeviceInterface>()
                    .HasIndex(b => new { b.CreatedDateTime, b.Id });

            modelBuilder.Entity<MfgApplicationLog>()
                    .HasIndex(b => new { b.CreatedDateTime, b.Id });

            modelBuilder.Entity<MfgExceptionLog>()
                    .HasIndex(b => new { b.CreatedDateTime, b.Id });

            #endregion

            #region Ignore Default Fields            
            modelBuilder.Entity<MfgProcessExecutionDetail>().Ignore(x => x.StartTime);
            modelBuilder.Entity<MfgProcessExecutionDetail>().Ignore(x => x.EndTime);
            modelBuilder.Entity<MfgProductionUnitTool>().Ignore(x => x.StartTime);
            modelBuilder.Entity<MfgProductionUnitTool>().Ignore(x => x.EndTime);
            modelBuilder.Entity<MfgProductionUnitOperationTool>().Ignore(x => x.StartTime);
            modelBuilder.Entity<MfgProductionUnitOperationTool>().Ignore(x => x.EndTime);
            modelBuilder.Entity<MfgProductionUnitInventory>().Ignore(x => x.StartTime);
            modelBuilder.Entity<MfgProductionUnitInventory>().Ignore(x => x.EndTime);
            modelBuilder.Entity<MfgBatch>().Ignore(x => x.StartTime);
            modelBuilder.Entity<MfgBatch>().Ignore(x => x.EndTime);
            modelBuilder.Entity<MfgInventory>().Ignore(x => x.StartTime);
            modelBuilder.Entity<MfgInventory>().Ignore(x => x.EndTime);
            modelBuilder.Entity<MfgSerialDevice>().Ignore(x => x.StartTime);
            modelBuilder.Entity<MfgSerialDevice>().Ignore(x => x.EndTime);
            modelBuilder.Entity<DlcProductionUnitState>().Ignore(x => x.StartTime);
            modelBuilder.Entity<DlcProductionUnitState>().Ignore(x => x.EndTime);
            #endregion Ignore Default Fields

            #region "RECON Serial Device Handling"

            modelBuilder.Entity<MfgSerialDevice>()
                .HasIndex(p => new { p.PlantId, p.MfgOrderId, p.SerialNumber });

            modelBuilder.Entity<MfgSerialDevice>()
                .HasIndex(p => new { p.PlantId, p.BatchNumber, p.SerialNumber });

            modelBuilder.Entity<MfgSerialDevice>()
                .HasIndex(p => new { p.PlantId, p.ProcessOrder, p.SerialNumber });

            modelBuilder.Entity<MfgSerialDevice>()
                .HasIndex(p => p.SerialNumber)
                .IsUnique();

            #endregion

        }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            AddTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is MfgSystemsModel && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    Type t = ((MfgSystemsModel)entity.Entity).GetType();
                    ((MfgSystemsModel)entity.Entity).CreatedDateTime = DateTimeOffset.UtcNow;
                    ((MfgSystemsModel)entity.Entity).Id = (((MfgSystemsModel)entity.Entity).Id == null || ((MfgSystemsModel)entity.Entity).Id == Guid.Empty) ? Guid.NewGuid() : ((MfgSystemsModel)entity.Entity).Id;

                    var info = t.GetProperty("Id").GetCustomAttributes(typeof(DatabaseGeneratedAttribute), true).Cast<DatabaseGeneratedAttribute>().Single();

                    if (info.DatabaseGeneratedOption != DatabaseGeneratedOption.Identity)
                    {
                        ((MfgSystemsModel)entity.Entity).Id = Guid.NewGuid();
                    }
                }
                ((MfgSystemsModel)entity.Entity).UpdatedDateTime = DateTimeOffset.UtcNow;
            }
        }
    }
}
