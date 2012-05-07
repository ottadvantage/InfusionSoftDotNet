using System;
using CookComputing.XmlRpc;

namespace InfusionSoftDotNet
{
    public interface InfusionSoftApiInterfaces : IXmlRpcProxy
    {
        #region AffiliateService
        [XmlRpcMethod("AffiliateService.affClawbacks")]
        XmlRpcStruct[] asAffClawbacks(string key, int affiliateId, string filterStartDate, string filterEndDate);

        [XmlRpcMethod("AffiliateService.affCommissions")]
        XmlRpcStruct[] asAffCommissions(string key, int affiliateId, string filterStartDate, string filterEndDate);

        [XmlRpcMethod("AffiliateService.affPayouts")]
        XmlRpcStruct[] asAffPayouts(string key, int affiliateId, string filterStartDate, string filterEndDate);

        [XmlRpcMethod("AffiliateService.affRunningTotals")]
        XmlRpcStruct[] asAffRunningTotals(string key, int[] affiliateIds);

        [XmlRpcMethod("AffiliateService.affSummary")]
        XmlRpcStruct[] asAffSummary(string key, int affiliateId, string filterStartDate, string filterEndDate);

        #endregion

        #region ContactService
        [XmlRpcMethod("ContactService.add")]
        int addCon(string key, XmlRpcStruct cMap);

        [XmlRpcMethod("ContactService.addToCampaign")]
        bool addToCampaign(string key, int contactId, int campaignId);

        [XmlRpcMethod("ContactService.addToGroup")]
        bool addToGroup(string key, int contactId, int groupId);

        [XmlRpcMethod("ContactService.findByEmail")]
        XmlRpcStruct[] findByEmail(string key, string email, Array fieldsToReturn);

        [XmlRpcMethod("ContactService.load")]
        XmlRpcStruct load(string key, int contactId, Array selectedFields);

        [XmlRpcMethod("ContactService.getNextCampaignStep")]
        int getNextCampaignStep(string key, int contactId, int campaignId);

        [XmlRpcMethod("ContactService.pauseCampaign")]
        bool pauseCampaign(string key, int contactId, int campaignId);

        [XmlRpcMethod("ContactService.removeFromCampaign")]
        bool removeFromCampaign(string key, int contactId, int campaignId);

        [XmlRpcMethod("ContactService.resumeCampaign")]
        bool resumeCampaign(string key, int contactId, int campaignId);

        [XmlRpcMethod("ContactService.resumeCampaignForContact")]
        bool resumeCampaignForContact(string key, int contactId, int campaignId);

        [XmlRpcMethod("ContactService.rescheduleCampaignStep")]
        int rescheduleCampaignStep(string key, Array contactIds, int campaignStepId);

        [XmlRpcMethod("ContactService.removeFromGroup")]
        bool removeFromGroup(string key, int contactId, int groupId);

        //TODO - MJG - what is equivalent of *struct params in Asp.net?
        //[XmlRpcMethod("ContactService.runActionSequence")]
        //XmlRpcStruct runActionSequence(string key, int contactId, int actionSequenceID, *struct params);
        //bool runActionSequence(string key, int contactId, int actionSequenceId, 

        [XmlRpcMethod("ContactService.update")]
        int updateCon(string key, int contactId, XmlRpcStruct data);
        #endregion

        #region DataService
        [XmlRpcMethod("DataService.echo")]
        string appEcho(string textToEcho);

        [XmlRpcMethod("DataService.add")]
        int dsAdd(string key, string table, XmlRpcStruct values);

        [XmlRpcMethod("DataService.load")]
        XmlRpcStruct dsLoad(string key, string table, int Id, Array fields);

        [XmlRpcMethod("DataService.update")]
        int dsUpdate(string key, string table, int Id, XmlRpcStruct cMap);

        [XmlRpcMethod("DataService.delete")]
        bool dsDelete(string key, string table, int Id);

        [XmlRpcMethod("DataService.findByField")]
        XmlRpcStruct[] dsFindByField(string key, string table, int limit, int page, string fieldName, string fieldValue, Array selectedFields);

        [XmlRpcMethod("DataService.query")]
        XmlRpcStruct[] dsQuery(string key, string table, int limit, int page, XmlRpcStruct queryData, Array selectedFields);

        [XmlRpcMethod("DataService.addCustomField")]
        int dsAddCustomField(string key, string context, string displayName, string dataType, int groupId);

        [XmlRpcMethod("DataService.authenticateUser")]
        int dsAuthenticateUser(string key, string username, string passwordHash);

        [XmlRpcMethod("DataService.getAppSetting")]
        String dsGetAppSetting(string key, string module, string setting);

        [XmlRpcMethod("DataService.getTemporaryKey")]
        String dsGetTemporaryKey(string key, string username, string passwordHash);

        [XmlRpcMethod("DataService.updateCustomField")]
        bool dsUpdateCustomField(string key, int customFieldId, XmlRpcStruct values);
        #endregion

        #region DiscountService
        [XmlRpcMethod("DiscountService.addFreeTrial")]
        int disAddFreeTrial(string key, string description, int freeTrialDays, int hidePrice, int subscriptionPlanId);

        [XmlRpcMethod("DiscountService.getFreeTrial")]
        XmlRpcStruct disGetFreeTrial(string key, int trialId);

        [XmlRpcMethod("DiscountService.addOrderTotalDiscount")]
        int disAddOrderTotalDiscount(string key, string name, string description, int applyDiscountToCommission, int percentOrAmt, int amt, int payType);

        [XmlRpcMethod("DiscountService.getOrderTotalDiscount")]
        XmlRpcStruct disGetOrderTotalDiscount(string key, int id);

        [XmlRpcMethod("DiscountService.addCategoryDiscount")]
        int disAddCategoryDiscount(string key, string name, string description, int applyDiscountToCommission, int amt);

        [XmlRpcMethod("DiscountService.getCategoryDiscount")]
        XmlRpcStruct disGetCategoryDiscount(string key, int id);

        [XmlRpcMethod("DiscountService.addCategoryAssignmentToCategoryDiscount")]
        int disAddCategoryAssignmentToCategoryDiscount(string key, int productId);

        [XmlRpcMethod("DiscountService.getCategoryAssignmentsForCategoryDiscount")]
        XmlRpcStruct disGetCategoryAssignmentsForCategoryDiscount(string key, int id);

        [XmlRpcMethod("DiscountService.addProductTotalDiscount")]
        int disAddProductTotalDiscount(string key, string name, string description, int applyDiscountToCommission, int productId, int percentOrAmt, int amt);

        [XmlRpcMethod("DiscountService.getProductTotalDiscount")]
        XmlRpcStruct disGetProductTotalDiscount(string key, int id);

        [XmlRpcMethod("DiscountService.addShippingTotalDiscount")]
        int disAddShippingTotalDiscount(string key, string name, string description, int applyDiscountToCommission, int percentOrAmt, int amt);

        [XmlRpcMethod("DiscountService.getShippingTotalDiscount")]
        XmlRpcStruct disGetShippingTotalDiscount(string key, int id);

        #endregion

        #region EmailService
        [XmlRpcMethod("APIEmailService.addEmailTemplate")]
        int esAddEmailTemplate(string key, string pieceTitle, string categories, string fromAddress, string toAddress, string ccAddress, string bccAddress, string subject, string textBody, string htmlBody, string contentType, string mergeContext);

        [XmlRpcMethod("APIEmailService.attachEmail")]
        bool esAttachEmail(string key, int ContactId, string fromName, string fromAddress, string toAddress, string ccAddresses, string bccAddresses, string contentType, string subject, string htmlBody, string textBody, string header, string receivedDate, string sentDate, int emailSentType);

        //[XmlRpcMethod("APIEmailService.createEmailTemplate")] // replaced by APIEmailService.addEmailTempale()
        //int esCreateEmailTemplate(string key, string templateTemplate, int userId, string fromAddress, string toAddress, string ccAddresses, string bccAddresses, string contentType, string subject, string htmlBody, string textBody);

        [XmlRpcMethod("APIEmailService.getAvailableMergeFields")]
        string[] esGetAvailableMergeFields(string key, string mergeContext);

        [XmlRpcMethod("APIEmailService.getEmailTemplate")]
        XmlRpcStruct esGetEmailTemplate(string key, int templateId);

        [XmlRpcMethod("APIEmailService.getOptStatus")]
        int esGetOptStatus(string key, string email);

        [XmlRpcMethod("APIEmailService.optIn")]
        bool esOptIn(string key, string email, string permissionReason);

        [XmlRpcMethod("APIEmailService.optOut")] // NOTE: Once invoked, customer must respond to double opt-in email themselves to trun on again.
        bool esOptOut(string key, string email, string revokeReason);

        [XmlRpcMethod("APIEmailService.sendEmail")] 
        bool esSendEmail(string key, string[] contactList, string fromAddress, string toADdress, string ccAddresses, string bccAddresses, string contentType, string htmlBody, string textBody);

        // Replaced by esSendTemplate() method
        //[XmlRpcMethod("APIEmailService.sendEmail")]
        //bool esSendEmail(string key, string[] contactList, int templateId);

        [XmlRpcMethod("APIEmailService.sendTemplate")]
        bool esSendTemplate(string key, string[] contactList, int templateId);

        [XmlRpcMethod("APIEmailService.updateEmailTemplate")]
        bool esUpdateEmailTemplate(string key, int templateId, string pieceTitle, string categories, string fromAddress, string toAddress, string ccAddress, string bccAddress, string subject, string textBody, string htmlBody, string contentType, string mergeContext);
        
        #endregion

        #region FileService
        [XmlRpcMethod("FileService.getFile")]
        string fsGetFile(string key, int FileId);

        [XmlRpcMethod("FileService.getDownloadUrl")]
        string fsGetDownloadUrl(string key, int FileId); // TODO could through a fault that gives back data in an XmlRpcStruct

        [XmlRpcMethod("FileService.uploadFile")]
        int fsUploadFile(string key, string FileName, string Base64EncodedData);

        [XmlRpcMethod("FileService.uploadFile")]
        int fsUploadFile(string key, string FileName, string Base64EncodedData, int ContactId);

        [XmlRpcMethod("FileService.replaceFile")]
        bool fsReplaceFile(string key, int FileId, string Base64EncodedData);

        [XmlRpcMethod("FileService.renameFile")]
        bool fsRenameFile(string key, int FileId, string fileName);

        #endregion

        #region InvoiceService
        [XmlRpcMethod("InvoiceService.createBlankOrder")]
        int isCreateBlankOrder(string key, int contactId, string description, string orderDate, int leadAffiliateId, int saleAffiliateId);

        [XmlRpcMethod("InvoiceService.addOrderItem")]
        bool isAddOrderItem(string key, int invoiceId, int productId, int type, double price, int quantity, string description, string notes);
        // type is one of [UNKNOWN = 0; SHIPPING = 1; TAX = 2; SERVICE = 3; PRODUCT = 4; UPSELL = 5; FINANCECHARGE = 6; SPECIAL = 7;]

        [XmlRpcMethod("InvoiceService.chargeInvoice")]
        XmlRpcStruct isChargeInvoice(string key, int invoiceId, string notes, int creditCardId, int merchantAccountId, bool bypassCommissions);

        //[XmlRpcMethod("InvoiceService.deleteInvoice")]
        //bool isDeleteInvoice(string key, int Id);

        [XmlRpcMethod("InvoiceService.deleteSubscription")]
        bool isDeleteSubscription(string key, int Id);

        [XmlRpcMethod("InvoiceService.addRecurringOrder")]
        int isAddRecurringOrder(string key, int contactId, bool allowDuplicate, int cProgramId, int qty, double price, bool allowTax, int merchantAccountId, int creditCardId, int affiliateId, int daysTillCharge);

        [XmlRpcMethod("InvoiceService.addRecurringCommissionOverride")]
        bool isAddRecurringCommissionOverride(string key, int recurringOrderId, int affiliateId, double amount, int payoutType, string description);

        [XmlRpcMethod("InvoiceService.createInvoiceForRecurring")]
        int isCreateInvoiceForRecurring(string key, int recurringOrderId);

        [XmlRpcMethod("InvoiceService.addManualPayment")]
        bool isAddManualPayment(string key, int invoiceId, double amt, string paymentDate, string paymentType, string paymentDescription, bool bypassCommissions);

        [XmlRpcMethod("InvoiceService.addPaymentPlan")]
        bool isAddPaymentPlan(string key, int invoiceId, bool autoCharge, int creditCardId, int merchantAccountId, int daysBetweenRetry, int maxRetry, double initialPmtAmt, string initialPmtDate, string planStartDate, int numPmts, int dayBetweenPmts);

        [XmlRpcMethod("InvoiceService.calculateAmountOwed")]
        Double isCalculateAmountOwed(string key, int invoiceId);

        [XmlRpcMethod("InvoiceService.getAllPaymentOptions")]
        XmlRpcStruct[] isGetAllPaymentOptions(string key);
        //Array
        //(
        //    [Credit Card] => Credit Card
        //    [Check] => Check
        //    [Cash] => Cash
        //    [Money Order] => Money Order
        //    [Adjustment] => Adjustment
        //    [Credit] => Credit
        //    [Refund] => Refund
        //)

        [XmlRpcMethod("InvoiceService.getPayments")]
        XmlRpcStruct[] isGetPayments(string key, int invoiceId);

        [XmlRpcMethod("InvoiceService.locateExistingCard")]
        int isLocateExistingCard(string key, int contactId, string last4);

        [XmlRpcMethod("InvoiceService.recalculateTax")]
        bool isRecalculateTax(string key, int invoiceId);

        [XmlRpcMethod("InvoiceService.validateCreditCard")]
        XmlRpcStruct isValidateCreditCard(string key, int creditCardId);

        [XmlRpcMethod("InvoiceService.getAllShippingOptions")]
        String[] isGetAllShippingOptions(string key);

        //[XmlRpcMethod("InvoiceService.getPluginStatus")]
        //string isGetPluginStatus(string key, string fullyQualifiedClassName);

        [XmlRpcMethod("InvoiceService.updateJobRecurringNextBillDate")]
        bool isUpdateJobRecurringNextBillDate(string key, int jobRecurringId, string newNextBillDate);

        [XmlRpcMethod("InvoiceService.addOrderCommisionOverride")]
        bool isAddOrderCommissionOverride(string key, int invoiceId, int affiliateId, int productId, int percentage, double amount, int payoutType, string description, string date);

        [XmlRpcMethod("InvoiceService.deactivateCreditCard")]
        bool isDeactivateCreditCard(string key, int creditCardId);

        #endregion

        #region ProductService
        [XmlRpcMethod("ProductService.getInventory")]
        int psGetInventory(string key, int productId);

        [XmlRpcMethod("ProductService.incrementInventory")]
        bool psIncrementInventory(string key, int productId);

        [XmlRpcMethod("ProductService.decrementInventory")]
        bool psDecrementInventory(string key, int productId);

        [XmlRpcMethod("ProductService.increaseInventory")]
        bool psIncreaseInventory(string key, int productId, int quantity);

        [XmlRpcMethod("ProductService.decreaseInventory")]
        bool psDecreaseInventory(string key, int productId, int quantity);

        [XmlRpcMethod("ProductService.deactivateCreditCard")]
        bool psDeactivateCreditCard(string key, int creditCardId);

        #endregion

        #region SearchService
        [XmlRpcMethod("SearchService.getAllReportColumns")]
        XmlRpcStruct ssGetAllReportColumns(string key, int savedSearchId, int userId);

        [XmlRpcMethod("SearchService.getSavedSearchResultsAllFields")]
        XmlRpcStruct ssGetSavedSearchResultsAllFields(string key, int savedSearchId, int userId, int pageNumber);

        [XmlRpcMethod("SearchService.getAvailableQuickSearches")]
        XmlRpcStruct ssGetAvailableQuickSearches(string key, int userId);

        [XmlRpcMethod("SearchService.quickSearch")]
        XmlRpcStruct ssQuickSearch(string key, int quickSearchType, int userId, int searchData, int page, int returnLimit);

        [XmlRpcMethod("SearchService.getDefaultQuickSearch")]
        string ssGetDefaultQuickSearch(string key, int userId);

        #endregion

        #region ShippingService
        [XmlRpcMethod("ShippingService.getAllShippingOptions")]
        XmlRpcStruct[] shsGetAllShippingOptions(string key);

        [XmlRpcMethod("ShippingService.getFlatRateShippingOption")]
        XmlRpcStruct shsGetFlatRateShippingOption(string key, int optionId);

        [XmlRpcMethod("ShippingService.getOrderTotalShippingOption")]
        XmlRpcStruct[] shsGetOrderTotalShippingOption(string key, int optionId);

        [XmlRpcMethod("ShippingService.getOrderTotalShippingRanges")]
        XmlRpcStruct[] shsGetOrderTotalShippingRanges(string key, int optionId);

        [XmlRpcMethod("ShippingService.getProductBasedShippingOption")]
        XmlRpcStruct shsGetProductBasedShippingOption(string key, int optionId);

        [XmlRpcMethod("ShippingService.getProductShippingPricesForProductShippingOption")]
        XmlRpcStruct shsGetProductShippingPricesForProductShippingOption(string key, int optionId);

        [XmlRpcMethod("ShippingService.getOrderQuantityShippingOption")]
        XmlRpcStruct shsGetOrderQuantityShippingOption(string key, int optionId);

        [XmlRpcMethod("ShippingService.getWeightBasedShippingOption")]
        XmlRpcStruct shsGetWeightBasedShippingOption(string key, int optionId);

        [XmlRpcMethod("ShippingService.getWeightBasedShippingRanges")]
        XmlRpcStruct shsGetWeightBasedShippingRanges(string key, int optionId);

        [XmlRpcMethod("ShippingService.getUpsShippingOption")]
        XmlRpcStruct shsGetUpsShippingOption(string key, int optionId);

        #endregion

        #region WebFormService
        [XmlRpcMethod("WebFormService.getMap")]
        XmlRpcStruct[] wfsGetMap(string key);
        #endregion
    }

}
