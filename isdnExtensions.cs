using System;
using System.Collections.Generic;
using System.Reflection;
using CookComputing.XmlRpc;

namespace InfusionSoftDotNet
{
    public class isdnExtensions
    {
        //TODO MJG
        // attachEmail(int contactId, string fromName, string fromAddress, string toAddress, string ccAddresses, string bccAddresses, string contentType, string subject, string htmlBody, string textBody, string header, string receivedDate, string sentDate)
        // createEmailTemplate(string templateTitle, int userId, string fromAddress, string toAddress, string ccAddresses, string bccAddresses, string contentType, string subjetc, string htmlBody, string textBody)
        // getEmailTemplate(int templateId)
        // optStatus(string email)
        // sendEmail(int[] contactIds, string fromAddress, string toAddress, string ccAddresses, string bccAddresses, string contentType, string subject, string htmlBody, string textBody)
        // sendTemplate(int[] contactIds, int templateId)
        // affClawbacks(int affiliateId, datetime filterStartDate, datetime filterEndDate)
        // affCommissions(int affiliateId, datetime filterStartDate, datetime filterEndDate)
        // affPayouts(int affiliateId, datetime filterStartDate, datetime filterEndDate)
        // affRunningTotals(int[] affiliateIds)
        // affSummary(int[] affiliateIds, datetime filterStartDate, datetime filterEndDate)

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
        /// addNote will add a ContactAction (note) to a contact's record. 
        /// </summary>
        /// <param name="Id">The contact's ID to update</param>
        /// <param name="ActionType">Values can be CALL, Email, Appointment, Fax, Letter, Other, Update</param>
        /// <param name="ActionDescription"></param>
        /// <param name="NoteToAdd">The actual text of the note</param>
        /// <returns></returns>
        public static Int32 AddNote(Int32 Id, string ActionType, string ActionDescription, string NoteToAdd)
        {
            int ret_value = 0;

            XmlRpcStruct note = new XmlRpcStruct();
            note.Add("Id", Id.ToString());
            note.Add("CreationDate", infuDate(DateTime.Now.ToString()));
            note.Add("ActionType", ActionType);
            note.Add("ActionDescription", ActionDescription);
            note.Add("CreationNotes", NoteToAdd);

            ret_value = isdnAPI.dsAdd("ContactAction", note);

            return ret_value;
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

        /// <summary>
        /// This overload of infuDate() will accept a timestamp as a string and will reformat that to reflect an InfusionSoft formatted date
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public static String infuDate(string timestamp)
        {
            string ret_value = string.Empty;

            DateTime newTimestamp = Convert.ToDateTime(timestamp);
            ret_value = infuDate(newTimestamp);

            return ret_value;
        }
        /// <summary>
        /// infuDate will accept a datetime value and return a string that has been formatted into an acceptable format for InfusionSoft dates
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public static String infuDate(DateTime timestamp)
        {
            string ret_value = string.Empty;

            ret_value = timestamp.ToString("yyy-MM-dd hh:mm:ss");

            return ret_value;
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

        /// <summary>
        /// UpdateContactNote does just what it says. Instead of overwriting the value in the notes field, it adds a new note to the previously existing data
        /// </summary>
        /// <param name="ContactId"></param>
        /// <param name="NewNote"></param>
        /// <returns></returns>
        public static Int32 UpdateContactNote(Int32 ContactId, string NewNote)
        {
            Int32 ret_val = 0;

            XmlRpcStruct contact = new XmlRpcStruct();
            // We want to return the value already in Notes field
            string[] returnFields = { "ContactNotes" };
            contact = isdnAPI.load(ContactId, returnFields);

            // If the load() function returned anything, there is a value stored in Contact notes so append the NewNote info to end of existing info before calling updateContact()
            if (contact.Count == 1)
            {
                string OldNotes = contact["ContactNotes"].ToString();
                contact["ContactNotes"] = NewNote + "\n" + OldNotes;
            } // If no value is returned, there is no value in the notes field so just go ahead and update the contact with the new note
            else
                contact["ContactNotes"] = NewNote;

            ret_val = UpdateContact(ContactId, contact);

            return ret_val;
        }

    }
}
