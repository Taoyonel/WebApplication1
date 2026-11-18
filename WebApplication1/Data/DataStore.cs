using SkillHub.Models;

namespace SkillHub.Data;

public static class DataStore
{
    public static List<UserAccount> Users = new List<UserAccount>();
    public static List<Listing> Listings = new List<Listing>();
    public static List<ServiceRequest> Requests = new List<ServiceRequest>();

    public static string[] Categories = { "Education", "Technology", "Design", "Home", "Music", "Fitness", "Business", "Beauty & Care" };

    private static int nextUserId = 1;
    private static int nextListingId = 1;
    private static int nextRequestId = 1;

    // ---------- SAMPLE DATA ----------
    public static void LoadSampleData()
    {
        AddUser("System Admin", "admin@skillhub.com", "Admin123!", "Admin");

        AddSample("Angelica Reyes", "angelica@skillhub.com", "Mathematics Tutor", "I can help with algebra, geometry, and basic calculus.", "Education", "Tutor", 300, 4.8);
        AddSample("Kristine Bautista", "kristine@skillhub.com", "English Language Tutor", "Friendly English lessons for speaking, writing, and grammar.", "Education", "Tutor", 250, 4.7);
        AddSample("Paolo Villanueva", "paolo@skillhub.com", "Science Tutor", "Physics, chemistry, and biology explained in a simple way.", "Education", "Tutor", 350, 4.8);
    }

    private static void AddSample(string name, string email, string title, string description, string category, string type, decimal rate, double rating)
    {
        UserAccount pro = AddUser(name, email, "Pass123!", "Professional");
        Listing listing = AddListing(pro.Id, title, description, category, type, rate);
        listing.Rating = rating;
    }

    // ---------- USERS ----------
    public static UserAccount AddUser(string fullName, string email, string password, string role)
    {
        UserAccount user = new UserAccount();
        user.Id = nextUserId;
        nextUserId++;
        user.FullName = fullName;
        user.Email = email;
        user.Password = password;
        user.Role = role;
        user.Location = "";
        user.Bio = "";
        Users.Add(user);
        return user;
    }

    public static UserAccount FindUserById(int id)
    {
        for (int i = 0; i < Users.Count; i++)
        {
            if (Users[i].Id == id)
            {
                return Users[i];
            }
        }
        return null;
    }

    public static UserAccount FindUserByEmail(string email)
    {
        for (int i = 0; i < Users.Count; i++)
        {
            if (Users[i].Email.ToLower() == email.ToLower())
            {
                return Users[i];
            }
        }
        return null;
    }

    public static void RemoveUser(int userId)
    {
        // Loop BACKWARDS when removing so no item gets skipped.

        // 1. remove the user's listings (and requests made to them)
        for (int i = Listings.Count - 1; i >= 0; i--)
        {
            if (Listings[i].OwnerId == userId)
            {
                RemoveListing(Listings[i].Id);
            }
        }

        // 2. remove requests the user sent
        for (int i = Requests.Count - 1; i >= 0; i--)
        {
            if (Requests[i].RequesterId == userId)
            {
                Requests.RemoveAt(i);
            }
        }

        // 3. remove the user
        for (int i = Users.Count - 1; i >= 0; i--)
        {
            if (Users[i].Id == userId)
            {
                Users.RemoveAt(i);
            }
        }
    }

    public static int CountUsersByRole(string role)
    {
        int count = 0;
        for (int i = 0; i < Users.Count; i++)
        {
            if (Users[i].Role == role)
            {
                count++;
            }
        }
        return count;
    }

    // ---------- LISTINGS ----------
    public static Listing AddListing(int ownerId, string title, string description, string category, string type, decimal rate)
    {
        Listing listing = new Listing();
        listing.Id = nextListingId;
        nextListingId++;
        listing.OwnerId = ownerId;
        listing.Title = title;
        listing.Description = description;
        listing.Category = category;
        listing.Type = type;
        listing.HourlyRate = rate;
        listing.Rating = 0;
        listing.IsActive = true;
        Listings.Add(listing);
        return listing;
    }

    public static Listing FindListing(int id)
    {
        for (int i = 0; i < Listings.Count; i++)
        {
            if (Listings[i].Id == id)
            {
                return Listings[i];
            }
        }
        return null;
    }

    public static void RemoveListing(int listingId)
    {
        for (int i = Requests.Count - 1; i >= 0; i--)
        {
            if (Requests[i].ListingId == listingId)
            {
                Requests.RemoveAt(i);
            }
        }
        for (int i = Listings.Count - 1; i >= 0; i--)
        {
            if (Listings[i].Id == listingId)
            {
                Listings.RemoveAt(i);
            }
        }
    }

    public static int CountListingsByOwner(int ownerId)
    {
        int count = 0;
        for (int i = 0; i < Listings.Count; i++)
        {
            if (Listings[i].OwnerId == ownerId)
            {
                count++;
            }
        }
        return count;
    }

    // ---------- REQUESTS ----------
    public static void AddRequest(int listingId, int requesterId, string message)
    {
        ServiceRequest request = new ServiceRequest();
        request.Id = nextRequestId;
        nextRequestId++;
        request.ListingId = listingId;
        request.RequesterId = requesterId;
        request.Message = message;
        request.Status = "Pending";
        request.DateSent = DateTime.Now;
        Requests.Add(request);
    }

    public static ServiceRequest FindRequest(int id)
    {
        for (int i = 0; i < Requests.Count; i++)
        {
            if (Requests[i].Id == id)
            {
                return Requests[i];
            }
        }
        return null;
    }

    public static bool HasPendingRequest(int listingId, int requesterId)
    {
        for (int i = 0; i < Requests.Count; i++)
        {
            if (Requests[i].ListingId == listingId && Requests[i].RequesterId == requesterId && Requests[i].Status == "Pending")
            {
                return true;
            }
        }
        return false;
    }
}