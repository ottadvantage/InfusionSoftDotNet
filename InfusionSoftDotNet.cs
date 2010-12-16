using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Web;
using System.Text;
using CookComputing.XmlRpc;

namespace InfusionSoftDotNet
{
    public interface InfusionSoftApiInterfaces : IXmlRpcProxy
    {
        #region ContactService
        [XmlRpcMethod("ContactService.add")]
        Int32 addCon(string key, XmlRpcStruct cMap);

        [XmlRpcMethod("ContactService.findByEmail")]
        XmlRpcStruct[] findByEmail(string key, string email, Array fieldsToReturn);

        [XmlRpcMethod("ContactService.load")]
        XmlRpcStruct load(string key, int contactId, Array selectedFields);

        [XmlRpcMethod("ContactService.addToCampaign")]
        bool addToCampaign(string key, int contactId, int campaignId);

        [XmlRpcMethod("ContactService.getNextCampaignStep")]
        int getNextCampaignStep(string key, int contactId, int campaignId);

        [XmlRpcMethod("ContactService.pauseCampaign")]
        bool pauseCampaign(string key, int contactId, int campaignId);

        [XmlRpcMethod("ContactService.removeFromCampaign")]
        bool removeFromCampaign(string key, int contactId, int campaignId);

        [XmlRpcMethod("ContactService.resumeCampaign")]
        bool resumeCampaign(string key, int contactId, int campaignId);

        [XmlRpcMethod("ContactService.rescheduleCampaignStep")]
        int rescheduleCampaignStep(string key, Array contactIds, int campaignStepId);

        [XmlRpcMethod("ContactService.addToGroup")]
        bool addToGroup(string key, int contactId, int groupId);

        [XmlRpcMethod("ContactService.removeFromGroup")]
        bool removeFromGroup(string key, int contactId, int groupId);

        //TODO - MJG - what is equivalent of *struct params in Asp.net?
        //[XmlRpcMethod("ContactService.runActionSequence")]
        //XmlRpcStruct runActionSequence(string key, int contactId, int actionSequenceID, *struct params);
        //bool runActionSequence(string key, int contactId, int actionSequenceId, 
        #endregion

        #region DataService
        [XmlRpcMethod("DataService.echo")]
        string appEcho(string textToEcho);

        [XmlRpcMethod("DataService.add")]
        Int32 dsAdd(string key, string table, XmlRpcStruct values);

        [XmlRpcMethod("DataService.load")]
        XmlRpcStruct dsLoad(string key, string table, int Id, Array fields);

        [XmlRpcMethod("DataService.update")]
        Int32 dsUpdate(string key, string table, Int32 Id, XmlRpcStruct cMap);

        [XmlRpcMethod("DataService.delete")]
        Boolean dsDelete(string key, string table, Int32 Id);

        [XmlRpcMethod("DataService.findByField")]
        XmlRpcStruct[] dsFindByField(string key, string table, Int32 limit, Int32 page, string fieldName, string fieldValue, Array selectedFields);

        [XmlRpcMethod("DataService.query")]
        XmlRpcStruct[] dsQuery(string key, string table, Int32 limit, Int32 page, XmlRpcStruct queryData, Array selectedFields);

        [XmlRpcMethod("DataService.addCustomField")]
        Int32 dsAddCustomField(string key, string context, string displayName, string dataType, int groupId);

        [XmlRpcMethod("DataService.authenticateUser")]
        Int32 dsAuthenticateUser(string key, string username, string passwordHash);

        [XmlRpcMethod("DataService.getAppSetting")]
        String dsGetAppSetting(string key, string module, string setting);

        [XmlRpcMethod("DataService.getTemporaryKey")]
        String dsGetTemporaryKey(string key, string username, string passwordHash);

        [XmlRpcMethod("DataService.updateCustomField")]
        Boolean dsUpdateCustomField(string key, Int32 customFieldId, XmlRpcStruct values);
        #endregion

        #region APIEmailService
        [XmlRpcMethod("APIEmailService.addEmailTemplate")]
        int esAddEmailTemplate(string key, string pieceTitle, string categories, string fromAddress, string toAddress, string ccAddress, string bccAddress, string subject, string textBody, string htmlBody, string contentType, string mergeContext);

        [XmlRpcMethod("APIEmailService.attachEmail")]
        bool esAttachEmail(string key, int ContactId, string fromName, string fromAddress, string toAddress, string ccAddresses, string bccAddresses, string contentType, string subject, string htmlBody, string textBody, string header, string receivedDate, string sentDate, int emailSentType);

        [XmlRpcMethod("APIEmailService.createEmailTemplate")]
        int esCreateEmailTemplate(string key, string templateTemplate, int userId, string fromAddress, string toAddress, string ccAddresses, string bccAddresses, string contentType, string subject, string htmlBody, string textBody);

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

        [XmlRpcMethod("APIEmailService.updateEmailTemplate")] 
        bool esUpdateEmailTemplate(string key, int templateId, string pieceTitle, string categories, string fromAddress, string toAddress, string ccAddress, string bccAddress, string subject, string textBody, string htmlBody, string contentType, string mergeContext);
        
        #endregion

        #region APIAffiliateService
        #endregion

        #region InvoiceService
        [XmlRpcMethod("InvoiceService.createBlankOrder")]
        Int32 isCreateBlankOrder(string key, int contactId, string description, DateTime orderDate, int leadAffiliateId, int saleAffiliateId);

        [XmlRpcMethod("InvoiceService.addOrderItem")]
        Boolean isAddOrderItem(string key, int invoiceId, int productId, int type, double price, int quantity, string description, string notes);
        // type is one of [UNKNOWN = 0; SHIPPING = 1; TAX = 2; SERVICE = 3; PRODUCT = 4; UPSELL = 5; FINANCECHARGE = 6; SPECIAL = 7;]

        [XmlRpcMethod("InvoiceService.chargeInvoice")]
        XmlRpcStruct isChargeInvoice(string key, int invoiceId, string notes, int creditCardId, int merchantAccountId, bool bypassCommissions);

        [XmlRpcMethod("InvoiceService.deleteInvoice")]
        Boolean isDeleteInvoice(string key, int Id);

        [XmlRpcMethod("InvoiceService.deleteSubscription")]
        Boolean isDeleteSubscription(string key, int Id);

        [XmlRpcMethod("InvoiceService.addRecurringOrder")]
        Int32 isAddRecurringOrder(string key, int contactId, bool allowDuplicate, int cProgramId, int qty, double price, bool allowTax, int merchantAccountId, int creditCardId, int affiliateId, int daysTillCharge);

        [XmlRpcMethod("InvoiceService.addRecurringCommissionOverride")]
        Boolean isAddRecurringComissionOverride(string key, int recurringOrderId, int affiliateId, double amount, int payoutType, string description);

        [XmlRpcMethod("InvoiceService.createInvoiceForRecurring")]
        Int32 isCreateInvoiceForRecurring(string key, int recurringOrderId);

        [XmlRpcMethod("InvoiceService.addManualPayment")]
        Boolean isAddManualPayment(string key, int invoiceId, double amt, DateTime paymentDate, string paymentType, string paymentDescription, bool bypassCommissions);

        [XmlRpcMethod("InvoiceService.addPaymentPlan")]
        Boolean isAddPaymentPlan(string key, int invoiceId, bool autoCharge, int creditCardId, int merchantAccountId, int daysBetweenRetry, int maxRetry, double initialPmtAmt, DateTime initialPmtDate, DateTime planStartDate, int numPmts, int dayBetweenPmts);

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
        Int32 isLocateExistingCard(string key, int contactId, string last4);

        [XmlRpcMethod("InvoiceService.recalculateTax")]
        Boolean isRecalculateTax(string key, int invoiceId);

        [XmlRpcMethod("InvoiceService.validateCreditCard")]
        XmlRpcStruct isValidateCreditCard(string key, int creditCardId);

        [XmlRpcMethod("InvoiceService.getAllShippingOptions")]
        String[] isGetAllShippingOptions(string key);

        [XmlRpcMethod("InvoiceService.getPluginStatus")]
        string isGetPluginStatus(string key, string fullyQualifiedClassName);

        [XmlRpcMethod("InvoiceService.updateJobRecurringNextBillDate")]
        Boolean isUpdateJobRecurringNextBillDate(string key, int jobRecurringId, DateTime newNextBillDate);

        #endregion
    }

}
