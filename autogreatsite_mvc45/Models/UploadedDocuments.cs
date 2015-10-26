using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Raurck.Models
{
    public class UploadedDocuments : IEnumerable<HttpPostedFileBase>
    {
        //HttpPostedFileBase
        private List<HttpPostedFileBase> _postedFiles;
        private List<HttpPostedFileBase> postedFiles
        {
            get
            {
                if (_postedFiles == null)
                {
                    _postedFiles = new List<HttpPostedFileBase>();
                }
                return _postedFiles;
            }
        }

        public void Add(HttpPostedFileBase f1)
        {
            postedFiles.Add(f1);
        }

        public IEnumerator<HttpPostedFileBase> GetEnumerator()
        {
            return postedFiles.GetEnumerator();
            //throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return postedFiles.GetEnumerator();
            //throw new NotImplementedException();
        }
    }
}