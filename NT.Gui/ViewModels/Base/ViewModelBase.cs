using System.Threading.Tasks;

namespace NT.Gui.ViewModels.Base
{
    /// <summary>
    /// Base class for ViewModels
    /// </summary>
    public abstract class ViewModelBase : BindableBase
    {
        #region Methods
        /// <summary>
        /// Calls the <see cref="LoadAllAsync"/> method used to load all viewmodel data.
        /// </summary>
        public virtual async Task InitializeAsync()
        {
            // Load suppliers
            await LoadAllAsync();
        }

        /// <summary>
        /// Loads all data from the database, and assigns it to the observable collections.
        /// </summary>
        protected abstract Task LoadAllAsync();      
        #endregion
    }
}