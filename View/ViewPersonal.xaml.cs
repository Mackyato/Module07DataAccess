namespace Module07DataAccess.View;
using Module07DataAccess.Services;
using Module07DataAccess.ViewModel;

public partial class ViewPersonal : ContentPage
{
	public ViewPersonal()
	{
		InitializeComponent();

		var personalViewModel = new PersonalViewModel();
		BindingContext = personalViewModel;
	}
}