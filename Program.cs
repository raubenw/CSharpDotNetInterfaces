using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CSharpDotNetInterfaces
{

    interface IStorable
    {
        void Load();
        void Save();
        Boolean NeedsSave { get; set; }
    }

    class Document : IStorable, INotifyPropertyChanged
    {

        private string _title;
        private Boolean mNeedsSave = false;
        public event PropertyChangedEventHandler PropertyChanged;

        public Document(string aTitle)
        {
            _title = aTitle;
            Console.WriteLine("Creating new document with title '{0}'", _title);
        }

        public void Load()
        {
            Console.WriteLine("Loading the document");
        }

        public void Save()
        {
            Console.WriteLine("Saving the document");
        }

        public String DocName
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value;
                NotifiyPropChanged("DocName");
            }
        }

        public Boolean NeedsSave
        {
            get
            {
                return mNeedsSave;
            }

            set
            {
                mNeedsSave = value;
                NotifiyPropChanged("NeedsSave");
            }
        }

        private void NotifiyPropChanged(string propName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }

    class Program
    {

        static void Main(string[] args)
        {

            Document doc = new Document("Document New title");

            doc.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                Console.WriteLine("The document property {0} has changed", e.PropertyName);
            };

            doc.DocName = "My New Document Name";
            doc.NeedsSave = true;

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}