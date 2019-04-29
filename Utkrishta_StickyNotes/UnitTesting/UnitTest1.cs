using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utkrishta_StickyNotes;
namespace UnitTesting
{

    [TestClass]
    public class UnitTest1
    {
        bool expected, actual;
        DataTable dt;
        [TestMethod]
        public void checkLogin()
        {
            expected = true;
            LoginBll bll = new LoginBll();
            bll.Username = "ut1";
            bll.UPassword = "ut";
            actual = bll.check();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RecheckLogin()
        {
            expected = true;
            LoginBll bll = new LoginBll();
            bll.Username = "ut";
            bll.UPassword = "ut";
            actual = bll.check();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void insertintocategory()
        {
            String expected, actual;
            expected = "inserted";
            CategoryBll category = new CategoryBll();
            category.CategoryType = "HEY";
            category.UserID = 3;
            actual = category.insert();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void checkuserid()
        {
            int expected, actual;
            expected = 3;
            LoginBll loginbll = new LoginBll();
            loginbll.Username = "ut";
            actual = loginbll.selectID();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteNote()
        {
            String expected, actual;
            expected = "Deleted Successfully";
            StickyNotesBll stickyNotesBll = new StickyNotesBll();
            stickyNotesBll.NoteID = 3;
            actual = stickyNotesBll.delete();
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void selectname()
        {
            string expected, actual;
            expected = "Utkrishta";
            StickyNotesBll sticky = new StickyNotesBll();
            sticky.UserID=3;
            actual = sticky.Getname();
            Assert.AreEqual(expected, actual);
        }
       

        [TestMethod]
        public void SearchNotes()
        {
            DataTable dt;
            StickyNotesBll stickyNotes = new StickyNotesBll();
            stickyNotes.searchvalue = "Hello";
            stickyNotes.UserID = 3;
            
            expected= true;
            dt = stickyNotes.searchNote();
            if (dt.Rows.Count > 0)
            {
                actual=true;
            }
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void reSearchNotes()
        {
            DataTable dt;
            StickyNotesBll stickyNotes = new StickyNotesBll();
            stickyNotes.searchvalue = "asdfg";
            stickyNotes.UserID = 3;

            expected = true;
            dt = stickyNotes.searchNote();
            if (dt.Rows.Count > 0)
            {
                actual = true;
            }
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CountNotes()
        {
            
            StickyNotesBll stickyNotes = new StickyNotesBll();
            stickyNotes.UserID = 3;
            expected= true;
            dt = stickyNotes.countNote();
            if (dt.Rows.Count > 0)
            {
                actual = true;
            }
            else
            {
                actual = false;
            }
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void getnotess()
        {
            StickyNotesBll stickyNotes = new StickyNotesBll();
            stickyNotes.UserID = 6;
            expected = true;
            dt = stickyNotes.getNote();
            if (dt.Rows.Count > 0)
            {
                actual=true;
            }
            else
            {
                actual = false;
            }
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void DisplayCategory()
        {
            CategoryBll category = new CategoryBll();
            category.UserID = 6;
            expected = true;
            dt = category.displaydatas();
            if (dt.Rows.Count > 0)
            {
                actual = true;
            }
            else
            {
                actual = false;
            }
            Assert.AreEqual(expected, actual);
        }

     
        [TestMethod]
        public void CompletedNotes()
        {
            StickyNotesBll stickyNotes = new StickyNotesBll();
            stickyNotes.UserID = 3;
            expected = true;
            dt = stickyNotes.NoofCompletedNotes();
            if (dt.Rows.Count > 0)
            {
                actual = true;
            }
            else
            {
                actual = false;
            }
            Assert.AreEqual(expected, actual);
        }
       
      





    }
}
