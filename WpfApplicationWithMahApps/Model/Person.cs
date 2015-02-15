using System.Collections.ObjectModel;
using System.ComponentModel;
using GalaSoft.MvvmLight;

namespace WpfApplicationWithMahApps.Model
{
   public class Person : ObservableObject
   {
      private string _name;
      public string Name
      {
         get { return _name; }
         set
         {
            _name = value;
            RaisePropertyChanged("Name");
         }
      }
      private string _title;
      public string Title
      {
         get { return _title; }
         set
         {
            _title = value;
            RaisePropertyChanged("Title");
         }
      }

      private bool _hasDetails;
      public bool HasDetails
      {
         get
         {
            return _hasDetails;
         }
         set
         {
            _hasDetails = value;
            RaisePropertyChanged("HasDetails");

         }
      }


      private string _profilePic;
      public string ProfilePic
      {
          get { return _profilePic; }
          set
          {
              _profilePic = value;
              RaisePropertyChanged("ProfilePic");
          }
      }
   }

}
