Date: 2025-06-02

0900 - Reviewed real-world eCommerce products and selected "MirrorMart" as the fictional company.
0930 - Conducted product research and documented 5 attributes: ID, Name, Price, Description, Category.
1000 - Designed MirrorMart logo using Canva and defined branding theme.
1030 - Created ASP.NET Core 8.0 MVC project in Visual Studio 2022 with Individual User Accounts and HTTPS enabled.
1100 - Initialized Git repository from Visual Studio and created DEV GitHub repository (MirrorMart-Ecommerce).
1130 - Pushed initial commit to GitHub and confirmed successful connection.
1200 - Modified _Layout.cshtml to update the title to "MirrorMart" and added a navigation link to the product catalogue.
1300 - Created Product model with 5 properties: ID, Name, Price, Description, Category.
1330 - Added Product DbSet to ApplicationDbContext.
1400 - Scaffolded full CRUD pages for the Product model using EF Core.
1430 - Added 5 sample product entries to the Product index view for testing display.
1500 - Created AboutController and About.cshtml to describe MirrorMart’s corporate HQ, staff, and product mission.
1530 - Added "About Us" link to top navigation bar.
1600 - Finalized layout structure and verified routing/navigation between Home, Products, and About pages.
1630 - Updated external README.md with project overview, product investigation, team details, and course info.
1700 - Documented flowchart for MVC structure and added it to the repo under /docs.
1730 - Reviewed and added individual comments in code to show contribution details.
1800 - Changed repository visibility to public: GitHub > Settings > Danger Zone > Make Public.
1830 - Final test and checklist confirmation to verify completion of steps 1–6.
1900 - Submitted final public GitHub link via Blackboard.

Team Members:
- Ravi Create : 
	Plan and Investigate , 
	ASP.NET Core 8.0 Web App, 
	Add "About Us" Page, 
- Roshan Singh: 
	Plan and Investigate , 
	Create ASP.NET Core 8.0 Web App, 
	Update Project Structure, 
	Create Product Model
- Olayemi Olanrewaju: 
	Plan and Investigate , 
	Create ASP.NET Core 8.0 Web App, 
	Create README Files
	Design Logo
	Update Company Profile


	2025-06-09 2335

Initial created 20250608234008_InitialCreate.Designer


	2025-06-09 2203

-Set Up the Mirror Model
 Created Models/Mirror.cs with properties:
 Id, Type, Price, Material, Size, Shape

-Created MirrorsController

-Styled Catalog Table

	2221

-Added About Us Page
Added AboutUs() method in HomeController.

Created Views/Home/AboutUs.cshtml with:

Company name: MirrorMart
Location: Imphal, India

Team:
 Roshan Singh Thokchom – CEO

 Ravi Prakash Gudipudi – Team Lead

 Olayemi Olanrewaju – Developer

	2238

Updated Navigation Bar
Added links to:

Mirror Catalog

	2246

Add the About Us
(inside _Layout.cshtml)

Security Practices
MVC architecture with clean separation

Razor views help prevent script injection

Identity setup is available if extended later