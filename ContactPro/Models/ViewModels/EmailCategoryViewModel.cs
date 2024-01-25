namespace ContactPro.Models.ViewModels

{
    public class EmailCategoryViewModel
    {
        public List<Contact>? Contacts { get; set; }
        public EmailData? EmailData { get; set; }

    }
}



/* 
 * Inside a ViewModel, the data can come from multiple classes. We may be joining datasets
 * together. We are joining EmailData and Contact Data. A ViewModel can have a bunch of different things in it
 */