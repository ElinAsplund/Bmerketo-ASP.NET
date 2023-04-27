using Bmerketo_WebApp.Models;

namespace Bmerketo_WebApp.Services;

public class ShowcaseService
{
	//FOR LEARNING PURPOSES

	//A LIST
	private readonly List<ShowcaseModel> _showcases = new()
    {
        new ShowcaseModel()
        {
            Ingress = "SHOP SHOP SHOP SHOP SHOP",
            Title = "Mighty golden throne Collection.",
            Button = new LinkButtonModel()
            {
                Url = "/products",
                Content = "SHOP NOW"
            },
            ImageUrl = "./images/chair.jpg"
        },
        new ShowcaseModel()
        {
            Ingress = "WELCOME TO BMERKETO SHOP",
            Title = "Exclusive Chair gold Collection.",
            Button = new LinkButtonModel()
            {
                Url = "/products",
                Content = "SHOP NOW"
            },
            ImageUrl = "./images/chair.jpg"
        }
    };

	//GET LATEST ENTRY IN THE LIST
	public ShowcaseModel GetLatest()
    {
        return _showcases.LastOrDefault()!;
    }


    //GET JUST ONE
	private readonly ShowcaseModel showcase = new ()
    {
        Ingress = "SHOP SHOP SHOP SHOP SHOP",
        Title = "Mighty golden throne Collection.",
        Button = new LinkButtonModel()
        {
            Url = "/products",
            Content = "SHOP NOW"
        },
        ImageUrl = "./images/chair.jpg"
    };

    //GET JUST ONE
    public ShowcaseModel GetShowcase()
    {
        return showcase;
    }

}
