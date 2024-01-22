using ContactPro.Models;

namespace ContactPro.Services.Interfaces
{
    public interface IAddressBookService
    {
        Task AddContactToCategoryAsync(int categoryId, int contactId);
        Task<bool> IsContactInCategory(int categoryId, int contactId);

        Task<IEnumerable<Category>> GetUserCategoriesAsync(string userId);


        //For a given contact return all the Category ids they are selected in
        Task<ICollection<int>> GetContactCategoryIdsAsync(int contactId);


        //For a given contact return all the Category names they are selected in
        Task<ICollection<Category>> GetContactCategoriesAsync(int contactId);

        Task RemoveContactFromCategoryAsync(int categoryId, int contactId);

        IEnumerable<Contact> SearchForContacts(string searchString, string userId);
    }
}
