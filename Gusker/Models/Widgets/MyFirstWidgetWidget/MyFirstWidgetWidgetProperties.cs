using System.ComponentModel.DataAnnotations;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;


namespace Sample.Models.Widgets
{
    public class MyFirstWidgetWidgetProperties : IWidgetProperties
    {
		[Required()]
		[EditingComponent(TextInputComponent.IDENTIFIER, Order = 10, Label = "Property 1", ExplanationText = "First property")]
		public string Prop1 { get; set; }
		[Required()]
		[EditingComponent(EmailInputComponent.IDENTIFIER, Order = 20, Label = "Email address", ExplanationText = "Your email address")]
		public string Email { get; set; }
		[EditingComponent(EmailInputComponent.IDENTIFIER, Order = 20, Label = "Description", ExplanationText = "Please enter the description")]
		public string Description { get; set; }
    }
}