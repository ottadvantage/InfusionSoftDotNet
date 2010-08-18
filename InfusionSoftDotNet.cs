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

        // TODO - InfusionSoft
        //[XmlRpcMethod("ContactService.resumeCampaign")]
        //bool resumeCampaign(string key, int contactId, int campaignId);

        [XmlRpcMethod("ContactService.rescheduleCampaignStep")]
        int rescheduleCampaignStep(string key, Array contactIds, int campaignStepId);

        [XmlRpcMethod("ContactService.addToGroup")]
        bool addToGroup(string key, int contactId, int groupId);

        [XmlRpcMethod("ContactService.removeFromGroup")]
        bool removeFromGroup(string key, int contactId, int groupId);

        // TODO - MJG
        //[XmlRpcMethod("ContactService.runActionSequence")]
        //XmlRpcStruct runActionSequence(string key, int contactId, int actionSequenceID, *struct params);
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
        XmlRpcStruct isGetAllPaymentOptions(string key);
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
        XmlRpcStruct[] isGetAllShippingOptions(string key);

        [XmlRpcMethod("InvoiceService.getPluginStatus")]
        string isGetPluginStatus(string key, string fullyQualifiedClassName);

        [XmlRpcMethod("InvoiceService.updateJobRecurringNextBillDate")]
        Boolean isUpdateJobRecurringNextBillDate(string key, int jobRecurringId, DateTime newNextBillDate);

        #endregion
    }

    public class isdnAPI
    {
        public static string _AppName = ConfigurationSettings.AppSettings["iSdk-AppName"];
        public static string _AppType = ConfigurationSettings.AppSettings["iSdk-AppType"];
        public static string _ApiKey = ConfigurationSettings.AppSettings["iSdk-ApiKey"];
        public static string _ApiURL = String.Format("https://{0}.{1}.com/api/xmlrpc",
            _AppName,
            (_AppType == "m" ? "mortgageprocrm" : "infusionsoft"));

        #region Utilities
        /// <summary>
        /// appEcho will return the string that you pass to it back from the InfusionSoft server. Good for testing your connectivity to the server.
        /// </summary>
        /// <param name="textToEcho">String to be echoed back to you</param>
        /// <returns>A string that is identical to the string you passed to this method.</returns>
        public static string appEcho(string textToEcho)
        {
            string return_value = null;

            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                return_value = api.appEcho(textToEcho);
            }
            catch (Exception ex)
            {
                return_value = String.Format("Error: Unable to echo server.<br />{0}<br />",
                    ex.Message);
            }

            return return_value;
        }

        #endregion

        #region ContactService
        #region Core methods
        public static Int32 add(XmlRpcStruct cMap)
        {
            Int32 ret_value = 0;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.addCon(_ApiKey, cMap);
            }
            catch (Exception ex)
            {
                ret_value = -1;
            }
            return ret_value;
        }

        public static XmlRpcStruct[] findByEmail(string email, string[] returnFields)
        {
            XmlRpcStruct[] retArray;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                retArray = api.findByEmail(_ApiKey, email, returnFields);
            }
            catch (Exception ex)
            {
                XmlRpcStruct fail = new XmlRpcStruct();
                fail.Add("ErrorMessage", ex.Message);
                XmlRpcStruct[] retFail = new XmlRpcStruct[1] { fail };
                retArray = retFail;
            }
            return retArray;
        }

        public static XmlRpcStruct load(int Id, string[] selectedFields)
        {
            XmlRpcStruct retContact;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                retContact = api.load(_ApiKey, Id, selectedFields);
            }
            catch (Exception ex)
            {
                XmlRpcStruct fail = new XmlRpcStruct();
                fail.Add("ErrorMessage", ex.Message);
                retContact = fail;
            }
            return retContact;
        }
        #endregion

        #region Follow up sequence methods
        public static bool addToCampaign(int contactId, int campaignId)
        {
            bool ret_value = false;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.addToCampaign(_ApiKey, contactId, campaignId);
            }
            catch (Exception ex)
            {
                ret_value = false;
            }
            return ret_value;
        }

        public static int getNextCampaignStep(int contactId, int campaignId)
        {
            int ret_value = -1;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.getNextCampaignStep(_ApiKey, contactId, campaignId);
            }
            catch (Exception ex)
            {
                ret_value = -1;
            }
            return ret_value;
        }

        public static bool pauseCampaign(int contactId, int campaignId)
        {
            bool ret_value = false;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.pauseCampaign(_ApiKey, contactId, campaignId);
            }
            catch (Exception ex)
            {
                ret_value = false;
            }
            return ret_value;
        }

        public static bool removeFromCampaign(int contactId, int campaignId)
        {
            bool ret_value = false;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.removeFromCampaign(_ApiKey, contactId, campaignId);
            }
            catch (Exception ex)
            {
                ret_value = false;
            }
            return ret_value;
        }

        //TODO resumeCampaign()

        public static int rescheduleCampaignStep(Array contactIds, int campaignStepId)
        {
            int ret_value = -1;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.rescheduleCampaignStep(_ApiKey, contactIds, campaignStepId);
            }
            catch (Exception ex)
            {
                ret_value = -1;
            }
            return ret_value;
        }
        #endregion

        #region Tag methods
        public static bool addToGroup(int contactId, int groupId)
        {
            bool ret_value = false;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.addToGroup(_ApiKey, contactId, groupId);
            }
            catch (Exception ex)
            {
                ret_value = false;
            }
            return ret_value;
        }

        public static bool removeFromGroup(int contactId, int groupId)
        {
            bool ret_value = false;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.removeFromGroup(_ApiKey, contactId, groupId);
            }
            catch (Exception ex)
            {
                ret_value = false;
            }
            return ret_value;
        }
        #endregion

        #region Action methods
        // TODO - MJG - gotta figure out the equivalent of *struct params in .Net
        //public XmlRpcStruct runActionSequence(int contactId, int actionSequenceID, *struct params)
        #endregion
        #endregion

        #region DataService
        public static Int32 dsAdd(string table, XmlRpcStruct values)
        {
            Int32 ret_value = -1;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.dsAdd(_ApiKey, table, values);
            }
            catch (Exception ex)
            {
                ret_value = -1;
            }
            return ret_value;
        }

        public static XmlRpcStruct dsLoad(string table, int Id, string[] fields)
        {
            XmlRpcStruct retStruct;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                retStruct = api.dsLoad(_ApiKey, table, Id, fields);
            }
            catch (Exception ex)
            {
                XmlRpcStruct fail = new XmlRpcStruct();
                fail.Add("ErrorMessage", ex.Message);
                retStruct = fail;
            }
            return retStruct;
        }

        public static Int32 dsUpdate(string table, Int32 Id, XmlRpcStruct fields)
        {
            Int32 ret_value = -1;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.dsUpdate(_ApiKey, table, Id, fields);
            }
            catch (Exception ex)
            {
                XmlRpcStruct fail = new XmlRpcStruct();
                fail.Add("ErrorMessage", ex.Message);
                ret_value = -1;
            }
            return ret_value;
        }

        public static Boolean dsDelete(string table, Int32 Id)
        {
            Boolean ret_value = false;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.dsDelete(_ApiKey, table, Id);
            }
            catch (Exception ex)
            {
                XmlRpcStruct fail = new XmlRpcStruct();
                fail.Add("ErrorMessage", ex.Message);
                ret_value = false;
            }
            return ret_value;
        }

        public static XmlRpcStruct[] dsFindByField(string table, Int32 limit, Int32 page, string fieldName, string fieldValue, string[] selectedFields)
        {
            XmlRpcStruct[] retStructArray;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                retStructArray = api.dsFindByField(_ApiKey, table, limit, page, fieldName, fieldValue, selectedFields);
            }
            catch (Exception ex)
            {
                XmlRpcStruct fail = new XmlRpcStruct();
                fail.Add("ErrorMessage", ex.Message);
                XmlRpcStruct[] retFail = new XmlRpcStruct[1] { fail };
                retStructArray = retFail;
            }
            return retStructArray;
        }

        public static XmlRpcStruct[] dsQuery(string table, Int32 limit, Int32 page, XmlRpcStruct queryData, string[] selectedFields)
        {
            XmlRpcStruct[] retStructArray;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                retStructArray = api.dsQuery(_ApiKey, table, limit, page, queryData, selectedFields);
            }
            catch (Exception ex)
            {
                XmlRpcStruct fail = new XmlRpcStruct();
                fail.Add("ErrorMessage", ex.Message);
                XmlRpcStruct[] retFail = new XmlRpcStruct[1] { fail };
                retStructArray = retFail;
            }
            return retStructArray;
        }

        public static Int32 dsAddCustomField(string context, string displayName, string dataType, Int32 groupId)
        {
            Int32 ret_value = -1;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.dsAddCustomField(_ApiKey, context, displayName, dataType, groupId);
            }
            catch (Exception ex)
            {
                XmlRpcStruct fail = new XmlRpcStruct();
                fail.Add("ErrorMessage", ex.Message);
                ret_value = -1;
            }
            return ret_value;
        }

        public static Int32 dsAuthenticateUser(string username, string passwordHash)
        {
            Int32 ret_value = -1;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.dsAuthenticateUser(_ApiKey, username, passwordHash);
            }
            catch (Exception ex)
            {
                XmlRpcStruct fail = new XmlRpcStruct();
                fail.Add("ErrorMessage", ex.Message);
                ret_value = -1;
            }
            return ret_value;
        }

        public static string dsGetAppSetting(string module, string setting)
        {
            string ret_value = string.Empty;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.dsGetAppSetting(_ApiKey, module, setting);
            }
            catch (Exception ex)
            {
                XmlRpcStruct fail = new XmlRpcStruct();
                fail.Add("ErrorMessage", ex.Message);
                ret_value = string.Empty;
            }
            return ret_value;
        }

        public static string dsGetTemporaryKey(string username, string passwordHash)
        {
            string ret_value = string.Empty;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.dsGetTemporaryKey(_ApiKey, username, passwordHash);
            }
            catch (Exception ex)
            {
                XmlRpcStruct fail = new XmlRpcStruct();
                fail.Add("ErrorMessage", ex.Message);
                ret_value = string.Empty;
            }
            return ret_value;
        }

        public static Boolean dsUpdateCustomField(Int32 customFieldId, XmlRpcStruct values)
        {
            Boolean ret_value = false;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.dsUpdateCustomField(_ApiKey, customFieldId, values);
            }
            catch (Exception ex)
            {
                XmlRpcStruct fail = new XmlRpcStruct();
                fail.Add("ErrorMessage", ex.Message);
                ret_value = false;
            }
            return ret_value;
        }

        #endregion

        #region APIEmailService
        /// <summary>
        /// Creates a new email template that can be used for future emails.
        /// mergeContext choices:Contact, ServiceCall, Opportunity and CreditCard
        /// contentType choices: html, text or multipart
        /// </summary>
        /// <param name="pieceTitle"></param>
        /// <param name="categories"></param>
        /// <param name="fromAddress"></param>
        /// <param name="toAddress"></param>
        /// <param name="ccAddress"></param>
        /// <param name="bccAddress"></param>
        /// <param name="subject"></param>
        /// <param name="textBody"></param>
        /// <param name="htmlBody"></param>
        /// <param name="contentType"></param>
        /// <param name="mergeContext"></param>
        /// <returns>Returns templateId of the created email template</returns>
        public static Int32 addEmailTemplate(string pieceTitle, string categories, string fromAddress, string toAddress, string ccAddress, string bccAddress, string subject, string textBody, string htmlBody, string contentType, string mergeContext)
        {
            Int32 ret_value = -1;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.esAddEmailTemplate(_ApiKey, pieceTitle, categories, fromAddress, toAddress, ccAddress, bccAddress, subject, textBody, htmlBody, contentType, mergeContext);
            }
            catch (Exception ex)
            {
                ret_value = -2;
            }
            return ret_value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ContactId"></param>
        /// <param name="fromName"></param>
        /// <param name="fromAddress"></param>
        /// <param name="toAddress"></param>
        /// <param name="ccAddresses"></param>
        /// <param name="bccAddresses"></param>
        /// <param name="contentType"></param>
        /// <param name="subject"></param>
        /// <param name="htmlBody"></param>
        /// <param name="textBody"></param>
        /// <param name="header"></param>
        /// <param name="receivedDate"></param>
        /// <param name="sentDate"></param>
        /// <param name="emailSentType"></param>
        /// <returns></returns>
        public static Boolean attachEmail(Int32 ContactId, String fromName, String fromAddress, String toAddress, String ccAddresses, String bccAddresses, String contentType, String subject, String htmlBody, String textBody, String header, String receivedDate, String sentDate, Int32 emailSentType)
        {
            Boolean ret_value = false;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.esAttachEmail(_ApiKey, ContactId, fromName, fromAddress, toAddress, ccAddresses, bccAddresses, contentType, subject, htmlBody, textBody, header, receivedDate, sentDate, emailSentType);
            }
            catch (Exception ex)
            {
                ret_value = false;
            }
            return ret_value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="templateTemplate"></param>
        /// <param name="userId"></param>
        /// <param name="fromAddress"></param>
        /// <param name="toAddress"></param>
        /// <param name="ccAddresses"></param>
        /// <param name="bccAddresses"></param>
        /// <param name="contentType"></param>
        /// <param name="subject"></param>
        /// <param name="htmlBody"></param>
        /// <param name="textBody"></param>
        /// <returns></returns>
        public static Int32 createEmailTemplate(String templateTemplate, Int32 userId, String fromAddress, String toAddress, String ccAddresses, String bccAddresses, String contentType, String subject, String htmlBody, String textBody)
        {
            Int32 ret_value = 0;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.esCreateEmailTemplate(_ApiKey, templateTemplate, userId, fromAddress, toAddress, ccAddresses, bccAddresses, contentType, subject, htmlBody, textBody);
            }
            catch (Exception ex)
            {
                ret_value = -1;
            }
            return ret_value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mergeContext"></param>
        /// <returns></returns>
        public static String[] getAvailableMergeFields(string mergeContext)
        {
            string[] ret_value = { "Error" };
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.esGetAvailableMergeFields(_ApiKey, mergeContext);
                // valid mergeContext values are html, text or multipart
            }
            catch (Exception ex)
            {
            }
            return ret_value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="templateId"></param>
        /// <returns></returns>
        public static XmlRpcStruct getEmailTemplate(Int32 templateId)
        {
            XmlRpcStruct ret_value = new XmlRpcStruct();
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.esGetEmailTemplate(_ApiKey, templateId);
            }
            catch (Exception ex)
            {
                ret_value = new XmlRpcStruct();
            }
            return ret_value;
        }

        /// <summary>
        /// getOptStatus indicates the status of a given customer found by email address
        /// </summary>
        /// <param name="key"></param>
        /// <param name="email"></param>
        /// <returns>Returns 0 if the customer is not opted in, 1 if they are single opted in, 2 if they are double opted in, </returns>
        public static Int32 getOptStatus(string email)
        {
            Int32 ret_value = -1;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.esGetOptStatus(_ApiKey, email);
            }
            catch (Exception ex)
            {
                ret_value = -2;
            }
            return ret_value;
        }

        /// <summary>
        /// OptIn contact
        /// </summary>
        /// <param name="key"></param>
        /// <param name="email"></param>
        /// <param name="permissionReason"></param>
        /// <returns>true if OptIn was successful, false if not. Will return false if already opted in</returns>
        public static Boolean optIn(string email, string permissionReason)
        {
            bool ret_value = false;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.esOptIn(_ApiKey, email, permissionReason);
            }
            catch (Exception ex)
            {
                ret_value = false;
            }
            return ret_value;
        }

        /// <summary>
        /// OptOut contact
        /// </summary>
        /// <param name="key"></param>
        /// <param name="email"></param>
        /// <param name="permissionReason"></param>
        /// <returns>true if OptOut was successful, false if not. Will return false if already opted out</returns>
        public static Boolean optOut(string email, string revokeReason)
        {
            bool ret_value = false;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.esOptOut(_ApiKey, email, revokeReason);
            }
            catch (Exception ex)
            {
                ret_value = false;
            }
            return ret_value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contactList"></param>
        /// <param name="fromAddress"></param>
        /// <param name="toADdress"></param>
        /// <param name="ccAddresses"></param>
        /// <param name="bccAddresses"></param>
        /// <param name="contentType"></param>
        /// <param name="htmlBody"></param>
        /// <param name="textBody"></param>
        /// <returns></returns>
        public static Boolean sendEmail(string[] contactList, string fromAddress, string toADdress, string ccAddresses, string bccAddresses, string contentType, string htmlBody, string textBody)
        {
            bool ret_value = false;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.esSendEmail(_ApiKey, contactList, fromAddress, toADdress, ccAddresses, bccAddresses, contentType, htmlBody, textBody);
            }
            catch (Exception ex)
            {
                ret_value = false;
            }
            return ret_value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="templateId"></param>
        /// <param name="pieceTitle"></param>
        /// <param name="categories"></param>
        /// <param name="fromAddress"></param>
        /// <param name="toAddress"></param>
        /// <param name="ccAddress"></param>
        /// <param name="bccAddress"></param>
        /// <param name="subject"></param>
        /// <param name="textBody"></param>
        /// <param name="htmlBody"></param>
        /// <param name="contentType"></param>
        /// <param name="mergeContext"></param>
        /// <returns></returns>
        public static Boolean updateEmailTemplate(int templateId, string pieceTitle, string categories, string fromAddress, string toAddress, string ccAddress, string bccAddress, string subject, string textBody, string htmlBody, string contentType, string mergeContext)
        {
            bool ret_value = false;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.esUpdateEmailTemplate(_ApiKey, templateId, pieceTitle, categories, fromAddress, toAddress, ccAddress, bccAddress, subject, textBody, htmlBody, contentType, mergeContext);
            }
            catch (Exception ex)
            {
                ret_value = false;
            }
            return ret_value;
        }
        #endregion

        #region APIAffiliateService
        #endregion

        #region InvoiceService
        #region core methods
        // public static Int32 createBlankOrder()
        // public static Boolean addOrderItem()
        // public static XmlRpcStruct chargeInvoice()
        // public static Boolean deleteInvoice()
        // public static Boolean deleteSubscription()
        #endregion

        #region Subscription methods
        public static Int32 addRecurringOrder(Int32 contactId, Boolean allowDuplicate, Int32 cProgramId, Int32 qty, Double price, Boolean allowTax, Int32 merchantAccountId, Int32 creditCardId, Int32 affiliateId, Int32 daysTillCharge)
        {
            Int32 ret_value = 0;

            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.isAddRecurringOrder(_ApiKey, contactId, allowDuplicate, cProgramId, qty, price, allowTax, merchantAccountId, creditCardId, affiliateId, daysTillCharge);
            }
            catch (Exception)
            {
                ret_value = 0;
            }

            return ret_value;
        }

        // public static Int32 addRecurringCommissionOverride()

        public static Int32 createInvoiceForRecurring(Int32 recurringOrderId)
        {
            Int32 ret_value = 0;

            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.isCreateInvoiceForRecurring(_ApiKey, recurringOrderId);
            }
            catch (Exception)
            {
                ret_value = 0;
            }

            return ret_value;
        }
        
        // public static Boolean updateJobRecurringNextBillDate()
        #endregion

        #region Payment methods
        // public static Boolean addManualPayment()
        // public static Boolean addPaymentPlan()
        // public static Double calculateAmountOwed()

        public static XmlRpcStruct getAllPaymentOptions()
        {
            XmlRpcStruct ret_value = new XmlRpcStruct();
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.isGetAllPaymentOptions(_ApiKey);
            }
            catch (Exception ex)
            {
                ret_value = new XmlRpcStruct();
            }
            return ret_value;
        }
        // Returns all valid payment types as set up in the CRM
        // Array
        // (
        //     [Credit Card] => Credit Card
        //     [Check] => Check
        //     [Cash] => Cash
        //     [Money Order] => Money Order
        //     [Adjustment] => Adjustment
        //     [Credit] => Credit
        //     [Refund] => Refund
        // )

        // public static array getPayments()

        public static Int32 locateExistingCard(int contactId, string last4)
        {
            Int32 cardId = 0;

            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                cardId = api.isLocateExistingCard(_ApiKey, contactId, last4);
            }
            catch (Exception)
            {
                cardId = 0;
            }

            return cardId;
        }

        // public static Boolean recalculateTax()
        // public static XmlRpcStruct validateCreditCard()
        #endregion

        #region Misc methods
        // public static array getAllShippingOptions()
        public static String getPluginStatus(string fullyQualifiedClassName)
        {
            String ret_value = string.Empty;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = _ApiURL;
                ret_value = api.isGetPluginStatus(_ApiKey, fullyQualifiedClassName);
            }
            catch (Exception ex)
            {
                ret_value = string.Empty;
            }
            return ret_value;
        }
        #endregion

        #endregion

    }

    public class isdnExtensions
    {
        /// <summary>
        /// AddContact is an abstraction of the isdnAPI.add() method
        /// </summary>
        /// <param name="Contact"></param>
        /// <returns></returns>
        public static Int32 AddContact(XmlRpcStruct Contact)
        {
            return isdnAPI.add(Contact);
        }

        /// <summary>
        /// This will add a given contact to a Group based on their email address. Only works on first returned instance of email address.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="GroupID"></param>
        /// <returns></returns>
        public static Boolean AddToGroup(string email, Int32 GroupID)
        {
            Int32 Id = GetIdFromEmail(email);

            return isdnAPI.addToGroup(Id, GroupID);
        }

        //public static bool addToGroup(int contactId, string groupName)
        //{
        //    int groupId;
        //    // determine groupID from groupName
        //    // now addToGroup using the groupID
        //    return addToGroup(contactId, groupID);
        //}

        //public static Boolean AuthenticateUser(Int32 contactId, string password)
        //public static Boolean AuthenticateUser(string userName, string password)
        //public static XmlRpcStruct Authenticateuser(string userName, string password, string[] fieldsToReturn)

        /// <summary>
        /// Delete the contact associated with the given Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="cMap"></param>
        /// <returns></returns>
        public static Boolean deleteContact(Int32 Id, XmlRpcStruct cMap)
        {
            Boolean ret_value = false;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = isdnAPI._ApiURL;
                ret_value = api.dsDelete(isdnAPI._ApiKey, "Contact", Id);
            }
            catch (Exception ex)
            {
                ret_value = false;
            }
            return ret_value;
        }

        /// <summary>
        /// Report the current version number of this DLL
        /// </summary>
        /// <returns></returns>
        public static string DllVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        /// <summary>
        /// GetIdFromEmail will return the first contactID that matches the email supplied. If you are looking for ALL of them, use isdnAPI.findByEmail() instead
        /// </summary>
        /// <param name="email"></param>
        /// <returns>the first contactID that matches the email supplied</returns>
        public static Int32 GetIdFromEmail(string email)
        {
            string resultsString = string.Empty;
            string[] returnFields = { "Id" };
            XmlRpcStruct[] results = isdnAPI.findByEmail(email, returnFields);
            if (results.Length > 0)
                return Convert.ToInt32(results[0]["Id"]);
            else
                return -1;
        }

        public static XmlRpcStruct[] ListTemplates(String pieceType)
        {
            XmlRpcStruct[] ret_value;
 
            XmlRpcStruct query = new XmlRpcStruct();
            query.Add("PieceType", pieceType);
            string[] returnFields = { "Id", "PieceTitle", "Categories" };

            XmlRpcStruct[] Templates = isdnAPI.dsQuery("Template", 1000, 0, query, returnFields);
            Int32 resultCount = Templates.Length;
            if (resultCount > 0)
            {
                ret_value = Templates;
            }
            else
            {
                XmlRpcStruct fail = new XmlRpcStruct();
                fail.Add("ErrorMessage", "No templates returned");
                XmlRpcStruct[] retFail = new XmlRpcStruct[1] { fail };
                ret_value = retFail;
            }

            return ret_value;
            
        }
        
        /// <summary>
        /// Check if a contact is a member of a group by their respective Ids
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="GroupId"></param>
        /// <returns></returns>
        public static Boolean MemberOfGroup(Int32 Id, Int32 GroupId)
        {
            bool found = false;

            XmlRpcStruct query = new XmlRpcStruct();
            query.Add("ContactId", Id.ToString());
            string[] returnFields = { "GroupId" };

            XmlRpcStruct[] results = isdnAPI.dsQuery("ContactGroupAssign", 1000, 0, query, returnFields);
            Int32 resultCount = results.Length;
            if (resultCount > 0)
                for (int i = 0; i < resultCount; i++)
                {
                    if (Convert.ToInt32(results[i]["GroupId"]) == GroupId)
                        found = true;
                }
            return found;
        }

        /// <summary>
        /// Returns a String List of all the group Ids the given Contact is a member of
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static List<string> MemberOfGroups(Int32 Id)
        {
            string Memberships = string.Empty;
            List<string> GroupIds = new List<string>();

            XmlRpcStruct query = new XmlRpcStruct();
            query.Add("ContactId", Id.ToString());
            string[] returnFields = { "GroupId" };

            XmlRpcStruct[] results = isdnAPI.dsQuery("ContactGroupAssign", 1000, 0, query, returnFields);
            Int32 resultCount = results.Length;
            if (resultCount > 0)
                for (int i = 0; i < resultCount; i++)
                {
                    GroupIds.Add(results[i]["GroupId"].ToString());
                }

            return GroupIds;
        }

        /// <summary>
        /// Show a string representing the appconfig variables that this DLL requires to operate properly
        /// </summary>
        /// <returns></returns>
        public static string ShowAppConfigs()
        {
            return string.Format("_AppName: {0}|_AppType: {1}|_ApiKey: {2}|_ApiURL: {3}", new object[] { isdnAPI._AppName, isdnAPI._AppType, isdnAPI._ApiKey, isdnAPI._ApiURL });
        }

        /// <summary>
        /// Will update the contact record for a given Id.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Contact"></param>
        /// <returns>Returns -1 if the update fails</returns>
        public static Int32 UpdateContact(Int32 Id, XmlRpcStruct Contact)
        {
            Int32 ret_value = 0;
            try
            {
                InfusionSoftApiInterfaces api = XmlRpcProxyGen.Create<InfusionSoftApiInterfaces>();
                api.Url = isdnAPI._ApiURL;
                ret_value = api.dsUpdate(isdnAPI._ApiKey, "Contact", Id, Contact);
            }
            catch (Exception ex)
            {
                ret_value = -1;
            }
            return ret_value;
        }

        /// <summary>
        /// This version of UpdateContact takes an email address, finds the first instance of this address and then updates it
        /// </summary>
        /// <param name="email"></param>
        /// <param name="Contact"></param>
        /// <returns>Returns -1 if update fails or user is not found</returns>
        public static Int32 UpdateContact(string email, XmlRpcStruct Contact)
        {
            // use email address to find Id
            string resultsString = string.Empty;
            string[] returnFields = { "Id" };
            XmlRpcStruct[] results = isdnAPI.findByEmail(email, returnFields);
            if (results.Length > 0)
            {
                return UpdateContact(Convert.ToInt32(results[0]["Id"]), Contact);
            }
            else
                return -1;
        }


    }
}
