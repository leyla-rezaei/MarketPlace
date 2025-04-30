using MarketPlace.Domain.Entities.Account;
using MarketPlace.Domain.Entities.Admin;
using MarketPlace.Domain.Entities.Categories;
using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Entities.Media;
using MarketPlace.Domain.Entities.Products;
using MarketPlace.Domain.Entities.StoretSettings;
using MarketPlace.Domain.Entities.StoretSettings.Selling.Shippings;
using MarketPlace.Domain.Entities.StoretSettings.Settings;
using MarketPlace.Domain.Entities.Tags;
using MarketPlace.Domain.Enums;
using MarketPlace.Domain.Enums.MultiMediaFiles;
using MarketPlace.Domain.Enums.Product;
using MarketPlace.Domain.Enums.Setting;
using MarketPlace.Infrastructure.Identity.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.Persistence.Data;

public class DataInitializer
{
    public static void Initialize(ApplicationDbContext context)
    {
        context.Database.Migrate();
        SeedData(context);
    }

    private static void SeedData(ApplicationDbContext context)
    {
        var storeTypeId = SeedStoreTypes(context);
        var storeId = SeedStores(context, storeTypeId);
        var timeZoneId = SeedTimeZone(context);
        var roleId = SeedRole(context);

        SeedBrand(context);
        SeedShippingClass(context, storeId);
        SeedCategory(context);
        SeedTag(context);
        SeedStoreReadingSetting(context, storeId);
        SeedStoreGeneralSetting(context, storeId, timeZoneId);
        SeedMainBusinessSetting(context, timeZoneId, roleId);
    }

    private static Guid SeedRole(ApplicationDbContext context)
    {
        if (context.Set<Role>().Any())
            return context.Set<Role>().First().Id;

        var role = new Role { Localizations = new List<RoleLocalization>() { } };

        var languages = SeedLanguage(context);
        foreach (var language in languages)
        {
            role.Localizations.Add(new RoleLocalization { Description = $"{language.Key} Description" });
        }
        context.Set<Role>().Add(role);
        context.SaveChanges();

        return role.Id;
    }

    private static void SeedMainBusinessSetting(ApplicationDbContext context, Guid timeZoneId, Guid NewUserDefaultRoleId)
    {
        if (context.Set<MainBusinessSetting>().Any()) return;

        var adminStoreId = context.Set<Store>().FirstOrDefault()?.Id;

        var mainBusinessSetting = new MainBusinessSetting
        {
            SiteUrl = "https://www.yoursite.com",
            Domain = "YourDomain",
            SuperAdministrationEmailAddress = "admin@example.com",
            NewUserDefaultRoleId = NewUserDefaultRoleId,
            TimeZoneId = timeZoneId,
            DateFormat = DateFormat.dmY,
            CustomDateFormat = "yyyy-MM-dd",
            TimeFormat = TimeFormat.gia,
            CustomTimeFormat = "HH:mm:ss",
            WeekStartOn = DayOfWeek.Saturday,
            AdminStoreId = adminStoreId ?? Guid.Empty,
            NumberOfCharacteriseToHoldInQueue = 5,
            DisallowedCommentKeys = string.Empty,
            HoldQueueWords = string.Empty,
            Localizations = new List<MainBusinessSettingLocalization>() { }
        };

        var languages = SeedLanguage(context);
        foreach (var language in languages)
        {
            mainBusinessSetting.Localizations.Add(new MainBusinessSettingLocalization
            {
                Key = language.Key,
                SiteTitle = "SiteTitle",
                Tagline = " Tagline"
            });
        }
        context.Set<MainBusinessSetting>().Add(mainBusinessSetting);
        context.SaveChanges();
    }

    private static void SeedStoreGeneralSetting(ApplicationDbContext context, Guid storeId, Guid timeZoneId)
    {
        if (context.Set<StoreGeneralSetting>().Any()) return;

        var storeGeneralSetting = new StoreGeneralSetting
        {
            StoreId = storeId,
            StoreSubDomian = "yoursubdomain",
            StoreSubDomianUrl = "https://yoursubdomain.yourdomain.com",
            TimeZoneId = timeZoneId,
            DateFormat = DateFormat.dmY,
            CustomDateFormat = "yyyy-MM-dd",
            TimeFormat = TimeFormat.gia,
            CustomTimeFormat = "HH:mm:ss",
            WeekStartOn = DayOfWeek.Saturday,
            Localizations = new List<StoreGeneralSettingLocalization>() { }
        };
        var languages = SeedLanguage(context);
        foreach (var language in languages)
        {
            storeGeneralSetting.Localizations.Add(new StoreGeneralSettingLocalization
            {
                Key = language.Key,
                Description = $"{language.Key} Description",
                Title = $"{language.Key} Title"
            });
        }
        context.Set<StoreGeneralSetting>().Add(storeGeneralSetting);
        context.SaveChanges();
    }

    private static List<Language> SeedLanguage(ApplicationDbContext context)
    {
        if (context.Set<Language>().Any())
            return new List<Language>();

        var languages = new List<Language>()
        {
            new Language
            {
                Name = "English",
                Key = "en-EN",
                LanguageNameWithItsCharacter = "English (US)",
                Country = "America"
            },
            new Language
            {
                Name = "Spanish",
                Key = "es-ES",
                 LanguageNameWithItsCharacter = "Spanish (Spain)",
                Country = "Spain"
            },
             new Language
             {
                 Name = "فارسی",
                 Key = "fa-IR",
                 LanguageNameWithItsCharacter = "Persian (Farsi)"
                 , Country = "Iran"
             },
            new Language
            {
                Name = "русский",
                Key = "ru-RU",
                LanguageNameWithItsCharacter = "русский (Россия)",
                Country = "Russia"
            },
        };
        context.Set<Language>().AddRange(languages);
        context.SaveChanges();

        return context.Set<Language>().ToList();
    }

    private static Guid SeedTimeZone(ApplicationDbContext context)
    {
        if (context.Set<Country>().Any())
            return context.Set<Country>().First().Id;

        var timeZone = new Country
        {
            Name = "Coordinated Universal Time"
        };
        context.Set<Country>().Add(timeZone);
        context.SaveChanges();

        return timeZone.Id;
    }


    private static void SeedStoreReadingSetting(ApplicationDbContext context, Guid storeId)
    {
        if (context.Set<StoreReadingSetting>().Any()) return;

        var storeReadingSetting = new StoreReadingSetting
        {
            StoreId = storeId,
            HomepageDisplay = HomepageDisplay.StaticPage,
            BlogPagesShowAtMost = 5
        };
        context.Set<StoreReadingSetting>().Add(storeReadingSetting);
        context.SaveChanges();
    }

    private static void SeedTag(ApplicationDbContext context)
    {
        if (context.Set<Tag>().Any()) return;

        var tag = new Tag { IsApproved = true };

        context.Set<Tag>().Add(tag);
        context.SaveChanges();
    }


    private static void SeedCategory(ApplicationDbContext context)
    {
        if (context.Set<Category>().Any()) return;

        var category = new Category
        {
            CategoryType = CategoryType.Product,
            Localizations = new List<CategoryLocalization>()
        };

        context.Set<Category>().Add(category);
        context.SaveChanges();

        var languages = SeedLanguage(context);
        foreach (var language in languages)
        {
            category.Localizations.Add(new CategoryLocalization
            {
                Key = language.Key,
                Title = $"{language.Key} Title",
                Slug = $"{language.Key} Slug",
                Description = $"{language.Key} Description",
                CategoryId = category.Id
            });
        }
        context.SaveChanges();
    }

    private static void SeedShippingClass(ApplicationDbContext context, Guid storeId)
    {
        if (context.Set<ShippingClass>().Any()) return;

        var shippingClass = new ShippingClass
        {
            ProductCount = 0,
            StoreId = storeId,
            Localizations = new List<ShippingClassLocalization> { }
        };

        var languages = SeedLanguage(context);
        foreach (var language in languages)
        {
            shippingClass.Localizations.Add(new ShippingClassLocalization
            {
                Key = language.Key,
                ClassName = $"{language.Key} ClassName",
                Description = $"{language.Key} Description",
                Slug = $"{language.Key} Slug"
            });
        }
        context.Set<ShippingClass>().Add(shippingClass);
        context.SaveChanges();
    }

    private static void SeedBrand(ApplicationDbContext context)
    {
        if (context.Set<Brand>().Any()) return;

        Guid logoId = Guid.NewGuid();
        var multiMediaFile = new MultiMediaFile
        {
            Id = logoId,
            MediaType = Domain.Enums.MediaType.Image,
            Url = "https://example.com/logo.jpg",
            UniqueUrl = "unique-url",
            FileSize = 1024,

            FileSizeType = FileSizeType.Small,
            Width = 100,
            Height = 100,
            MediaContentType = MediaContentType.Logo,
            Localizations = new List<MultiMediaFileLocalization>() { }
        };

        var languages = SeedLanguage(context);
        foreach (var language in languages)
        {
            multiMediaFile.Localizations.Add(new MultiMediaFileLocalization
            {
                Key = language.Key,
                FileName = $"{language.Key} FileName "
            });
        }
        context.Set<MultiMediaFile>().Add(multiMediaFile);
        context.SaveChanges();

        var brand = new Brand
        {
            IsApproved = true,
            BrandType = BrandType.Forgen,
            RegistrationUrl = "https://example.com/registration",
            LogoId = logoId,
            Localizations = new List<BrandLocalization>() { }
        };

        foreach (var language in languages)
        {
            brand.Localizations.Add(new BrandLocalization
            {
                Key = language.Key,
                Name = $"{language.Key} Brand",
                Description = $"{language.Key} Description"
            });
        }
        context.Set<Brand>().Add(brand);
        context.SaveChanges();
    }

    private static Guid SeedStoreTypes(ApplicationDbContext context)
    {
        if (context.Set<StoreType>().Any())
            return context.Set<StoreType>().First().Id;
        var languages = SeedLanguage(context);

        var storeType = new StoreType
        {
            Localizations = new List<StoreTypeLocalization>() { }
        };

        foreach (var language in languages)
        {
            storeType.Localizations.Add(new StoreTypeLocalization
            {
                Key = language.Key,
                Type = $"{language.Key} Type"
            });
        }
        context.Set<StoreType>().Add(storeType);
        context.SaveChanges();

        return storeType.Id;
    }

    private static Guid SeedStores(ApplicationDbContext context, Guid storeTypeId)
    {
        var user = new User
        {
            PhoneNumber = "09377576601",
            Email = "leilarezaei.prog@gmail.com",
            Localizations = new List<UserLocalization>() { }
        };
        var languages = SeedLanguage(context);
        foreach (var language in languages)
        {
            user.Localizations.Add(new UserLocalization
            {
                Key = language.Key,
                FirstName = $"{language.Key} FirstName",
                LastName = $"{language.Key} LastName ",
                FullName = $"{language.Key} FullName"
            });
        }
        context.Set<User>().Add(user);
        context.SaveChanges();

        Guid storeIconId = Guid.NewGuid();
        var multiMediaFile = new MultiMediaFile
        {
            Id = storeIconId,
            MediaType = MediaType.Image,
            Url = "https://example.com/icon.jpg",
            UniqueUrl = "unique-url",
            FileSize = 1024,

            FileSizeType = FileSizeType.Small,
            Width = 100,
            Height = 100,
            MediaContentType = MediaContentType.Logo,
            Localizations = new List<MultiMediaFileLocalization>() { }
        };

        foreach (var language in languages)
        {
            multiMediaFile.Localizations.Add(new MultiMediaFileLocalization
            {
                Key = language.Key,
                FileName = $"{language.Key} FileName "
            });
        }
        context.Set<MultiMediaFile>().Add(multiMediaFile);
        context.SaveChanges();


        if (context.Set<Store>().Any())
            return context.Set<Store>().First().Id;

        var storeAdmin = new StoreAdmin
        {
            AdminId = user.Id
        };

        var store = new Store
        {
            OwnerId = user.Id,
            StoreTypeId = storeTypeId,
            StoreIconId = storeIconId,
            Domain = string.Empty,
            StoreAdmins = new List<StoreAdmin>
            {
                storeAdmin
            }
        };
        context.Set<Store>().Add(store);
        context.SaveChanges();
        return store.Id;
    }
}