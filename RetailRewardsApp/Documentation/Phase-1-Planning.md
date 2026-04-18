For Context: This is essentially a notes doc. Im using it to track progress as well as leave helpful notes and 
write stuff down for myself.

03/09/2026

- Task: Get all pages created and be able to transfer between each other. No details.

- Structure on first look: 
	- Login
	- Home
		- Notification Detail
		- History Detail
	- Scan
	- Menu
		- Item Detail
	- Offers
		- Offer Detail
	- Profile
		- Edit Profile
		- Notification Detail
		- History Detail

- Completed thus far:
	- Login
	- Home
		- Notification Detail
	- Scan
	- Menu
	- Offers
	- Profile

- To-Do:
	- History Detail
	- Item Detail
	- Offer Detail
	- Edit Profile

03/12/2026

- Task (Mobile): Finish getting all pages created and connected and begin working on services (back to core planning)
	- Completed!

- Task (Core): Begin working on Services
	- User
		- Transactions, Notifications
	- Item
	- Offer
	- Location
		- Items, Offers
	- Notification
	- Company
		- Businesses (not concerned yet, not scope creeping.)
	- Business
		- Locations (also not concerned yet.)
	- Transaction
		- TransactionItem
	- TransactionItem

- Completed so far:
	- Beginning stages of ItemService:
		- Loads dummy Business, Location, & Location Inventory to return a list of items

- I think i want to create a Location service and do the whole business/location thing there, 
then have a "GetLocation" func in the ItemService. I know its dummy info but i feel like itd 
be better in a real production environment.

- To-Do:
	- LocationService
	- NotificationService
	- OfferService
	- TransactionService
	- UserService

03/14/2026

- Task: Complete Location and User services, if time allows either edit ItemService or start on the others

- I want to do Location and User first as these are the most overarching items 
(at least before i get into Business & Company, but I don't want to scope creep.)

- Locations have Items and Offers, Users have Notifications and Transactions

- First thinking is:
	- Location needs:
		- GetLocation
		- GetLocationInventory
		- GetBusiness
		- GetLocationOffers

	- User needs:
		- GetUser
		- GetNotifications
		- GetTransactions (maybe GetTransactionHistory)

- Upon review I went ahead and made an entire FakeDatabaseService class 
that functions like a DB with tables and such, then redid ItemService 
to match as well as begun LocationService 
	- (maybe completed? but im not sure yet.)

- Next task is to complete all services so the following time we can begin populating screens with fake data.

- To-Do: 
	- UserService
	- OfferService
	- TransactionService
	- etc. on the services
	- if time allows, begin testing

03/16/2026

- Core Progress:
	- Finished the services as I know to be done
	- As I continue to integrate the services into the VM's i'm sure 
	they'll change slightly but for main setup i think this is complete

- Mobile Progress:
	- Having finished main core models and services we're coming back to the views. 
	currently i am now attempting to integrate the services into the views/viewmodels 
	to get the data to be populated into the views before going in depth on design.

- Currently I am working on:
	- LoginVM
	- HomeVM

- To-Do:
	- Complete Login to Home/Main
	- Begin other VM's going in the direction of the control flow:
		- Home
		- Scan
		- Menu
		- Offers
		- Profile


3/19/2026

- Task: I don't have a very clear direction today other than the viewmodels, ill either work to finish the 
login -> home/main flow or move to whichever VM flow i think i wanna do.


3/24/2026
- So Far: Login to Home/Main works, and data is populating into the home. Wakaka!
- Task: Get similar data populating into other views (Scan, Menu, Offers, Profile)
	- Scan:
		- User.PhoneNumber (for now until i get a QR code api)
	- Menu:
		- Location.Inventory
	- Offers: 
		- Location.Offers
	- Profile:
		- User: Name, Email, Password, Phone number, Points, RegisteredLocation, etc.

- Success = true!
- All relevant data seems to be populating, anything extra can come later but its good progress and 
proof of concept. Wakaka! Next task im thinking is either to continue data flow into the smaller views
or start getting UI going on the views with the data thats there now.


3/30/2026
- So Far: All main pages have data populating
- Task: One of two or both
	- Begin UI for Login and maybe Home
	- Finish getting data populated to smaller/rest of the views

- Success = eh
- I've begun getting the login screen kind of how i want and planned out what i want for it nicely, but progress is slow a bit. 

3/31/2026
- So Far: Login screen has been planned with general layout and UI effects, and has been started.
- Task: Finish the Login screen, if its not as fancy as I want it to be yet thats okay but just the general idea.

- Success = eh
- You can get through it and it kinda resembles how i want it to, at least logging in anyways, 
but i havent done sign up but it would be nearly the same pretty much




4/3/2026
- So Far: Partial Login screen UI achieved, very basic at the moment.

- Step Back - Overall Plan until 4/9
	- Each page has a basic UI containing the main parts and positions of the end result
	- Each page and its subsidaries has proper function and switch betweens

	- General task range to complete each day (not super strict but lets try)
		- 4/3 - Complete Login & Home UI, add functionality to Home subsidiaries, if not too exhausted maybe do UI for those
			- Home Subsidiaries: NotificationDetailPage, HistoryDetailPage, ItemDetailPage

		- 4/4 
			- If UI for Home subsidiaries not completed, complete them & Scan maybe start on Menu
			- Else, Complete Scan & Menu
				- (Menu subsidiary is ItemDetailPage)
		- 4/6 - Complete Menu & Deals, possibly Deals Subsidiary functionality (OfferDetailPage)
		- 4/7 - Complete Deals Subsidiary UI if not done, Complete Profile
		- 4/8 - Complete Profile Subsidiary (EditProfilePage)
		- 4/9 - Final checks/extra day if needed

- Thoughts for tasks after this series of tasks:
	- QR Code API
	- AI Suggestions API
	- Improved UI and flair each screen

- With all that said, task for today is:
	- Complete Login & Home UI, at least add functionality for Home subsidiaries possibly add UI as well.

- Success = true!
- Login and Home are at a basic but satisfying point to me, and data/functionality propagates into home subsidiaries,
but only for NotificationDetail and HistoryDetail (now TransactionDetail). ItemDetail still needs to be done but its fine for 
tonight.



4/6/2026
- So Far: Completed Login and Home basic UI and functionality into Notification & Transaction Detail
- Skipped 4/4 due to wanting to draw instead, but that was the point of the free day!

- Task today:
	- Complete functionality & basic UI for ItemDetail, Scan, and begin or complete Menu


- Success = true!
- ItemDetail now seems to have full functionality and UI set up, same as Scan and Menu, menu is able to navigate into ItemDetail 
very well, as well as TransactionDetail navigating into ItemDetail. Wakaka! 
- Next task should be Deals, OfferDetail, and Profile.



4/7/2026
- So Far: Completed Home, Scan, and Menu and their subsidiaries

- Task Today:
	- Deals screen and subsidiary (OfferDetail), possibly Profile (at least maybe functionality)


- Success = Mostly
- Deals screen and subsidiary is complete, but i didnt get to profile. But navigation between offer, offer detail, and item detail
is good. Next time we finish Profile and thats all i wanted to do before I left for Tampa on 4/9.



4/8/2026
- So Far: Completed Home, Scan, Menu, Deals, and their subsidiaries

- Task today:
	- Profile, maybe EditProfile, but im pretty tired.


- Success = Mostly
- I did complete Profile, but not EditProfile, like i thought. This is my 3rd of 4 nights in a row so I was really tired.



4/9/2026
- So Far: Completed Home, Scan, Menu, Deals, and their subsidiaries, as well as Profile.

- Task Today: 
	- EditProfile

- Real quick check for my expectations of what I wanted to get done by today:

	- Overall Plan until 4/9
		- ~~Each page has a basic UI containing the main parts and positions of the end result~~
		- ~~Each page and its subsidaries has proper function and switch betweens~~


		- 4/3 - ~~Complete Login & Home UI, add functionality to Home subsidiaries, if not too exhausted maybe do UI for those~~
			  - Home Subsidiaries: ~~NotificationDetailPage, HistoryDetailPage, ItemDetailPage~~

		- 4/4 
			- ~~If UI for Home subsidiaries not completed, complete them & Scan maybe start on Menu~~
			- Else, Complete Scan & Menu
				- (Menu subsidiary is ItemDetailPage)

		- 4/6 - ~~Complete Menu & Deals, possibly Deals Subsidiary functionality (OfferDetailPage)~~

		- 4/7 - ~~Complete Deals Subsidiary UI if not done, Complete Profile~~
		
		- 4/8 - ~~Complete Profile Subsidiary (EditProfilePage)~~ (finished today 4/9)

- Success = True!
- I also added some navigation from TransactionDetail to OfferDetail, but otherwise thats everything! Good job me!
- So after I get back from Tampa, next steps is this:
	- QR Code API
	- AI Suggestions API
	- Improved UI and flair each screen
- Probably in that order also. Get the data and everything flowing and set up first thing, then we can worry about making it all
pretty and everything.



4/17
- Took a little break, now we're back. just did the QR code package today.


4/18
- Task: get a satisfying amount of the agentic AI thing going. i just installed the nuGet package for semantic kernel and im 
getting the API key for Gemini right now. Im not sure what the point of stopping will be today, but i just wanna do some 
satisfying progress with it. maybe just having a testable result or something.

- success = true
- i got in a AIService interface for if i ever change out models, and added a GeminiService from it for now. i added the api key to
user secrets for security purposes, and got a successful query/response from the flash 2.5 model. that response for now is good
enough to me, now im gonna start thinking:
	- how to implement it into the UI
	- give it a basic UI and add it in so everything technical has been done and given a basic UI then we can work to make it 
	really pretty.

