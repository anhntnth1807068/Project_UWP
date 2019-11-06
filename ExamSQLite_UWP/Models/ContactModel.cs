using ExamSQLite_UWP.Entity;
using ExamSQLite_UWP.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSQLite_UWP.Models
{
    class ContactModel
    {
        public bool Insert(Contact contact)
        {
            try
            {
                using (var stt = SQLiteUtil.GetIntances().Connection.Prepare("INSERT INTO Note (Name, PhoneNumber) VALUES ( ? , ?)"))
                {
                    stt.Bind(1, contact.Name);
                    stt.Bind(2, contact.PhoneNumber);
                    
                    stt.Step();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return false;
        }

        public List<Contact> Select()
        {
            try
            {
                List<Contact> lstNote = new List<Contact>();
                using (var stt = SQLiteUtil.GetIntances().Connection.Prepare("SELECT * from Note"))
                {
                    while (stt.Step() == SQLitePCL.SQLiteResult.ROW)
                    {
                        var getContact = new Contact();
                        getContact.Id = Convert.ToInt32(stt[0]);
                        getContact.Name = (string)stt[1];
                        getContact.PhoneNumber = (string)stt[2];
                        lstNote.Add(getContact);
                    }
                    return lstNote;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        //public Contact SelectOneItem(int? id)
        //{
        //    try
        //    {
        //        var getContact = new Contact();
        //        using (var stt = SQLiteUtil.GetIntances().Connection.Prepare("SELECT * from Note Where Id = ?"))
        //        {
        //            stt.Bind(1, id);
        //            if (stt.Step() == SQLitePCL.SQLiteResult.ROW)
        //            {
        //                getContact.Name = (string)stt[1];
        //                getContact.PhoneNumber = (string)stt[2];
        //            }
        //            return getContact;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex.Message);
        //        return null;
        //    }
        //}

        }
    }

