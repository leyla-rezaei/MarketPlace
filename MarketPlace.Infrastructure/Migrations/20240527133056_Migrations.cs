using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketPlace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "localization");

            migrationBuilder.EnsureSchema(
                name: "product");

            migrationBuilder.EnsureSchema(
                name: "base");

            migrationBuilder.EnsureSchema(
                name: "media");

            migrationBuilder.EnsureSchema(
                name: "comment");

            migrationBuilder.EnsureSchema(
                name: "rate");

            migrationBuilder.EnsureSchema(
                name: "selling");

            migrationBuilder.EnsureSchema(
                name: "store_setting");

            migrationBuilder.EnsureSchema(
                name: "order");

            migrationBuilder.EnsureSchema(
                name: "main_setting");

            migrationBuilder.EnsureSchema(
                name: "site_setting");

            migrationBuilder.EnsureSchema(
                name: "payment_method");

            migrationBuilder.EnsureSchema(
                name: "post");

            migrationBuilder.EnsureSchema(
                name: "content");

            migrationBuilder.EnsureSchema(
                name: "tag");

            migrationBuilder.EnsureSchema(
                name: "payment");

            migrationBuilder.EnsureSchema(
                name: "selling_setting");

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    ParentCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CategoryType = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalSchema: "product",
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "base",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                schema: "base",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                schema: "base",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageNameWithItsCharacter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MainStoreMediaOptionSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    ThumbnailWidth = table.Column<int>(type: "int", nullable: false),
                    ThumbnailHeight = table.Column<int>(type: "int", nullable: false),
                    IsCropThumbnailToExactDimensions = table.Column<bool>(type: "bit", nullable: false),
                    MediumSizeMaxWidth = table.Column<int>(type: "int", nullable: false),
                    MediumSizeMaxHeight = table.Column<int>(type: "int", nullable: false),
                    LargeSizeMaxWidth = table.Column<int>(type: "int", nullable: false),
                    LargeSizeMaxHeight = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainStoreMediaOptionSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MultiMediaFiles",
                schema: "media",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    MediaType = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniqueUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    FileSizeType = table.Column<int>(type: "int", nullable: true),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    MediaContentType = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultiMediaFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Value = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StoreSliders",
                schema: "store_setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreSliders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StoreTypes",
                schema: "store_setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                schema: "tag",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    TagType = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Themes",
                schema: "site_setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZoneRegions",
                schema: "selling_setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZoneRegions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryLocalizations",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryLocalizations_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "product",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proviences",
                schema: "base",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proviences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proviences_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "base",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyLocalizations",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symbole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrencyLocalizations_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "base",
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BrandType = table.Column<int>(type: "int", nullable: false),
                    RegistrationUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brands_MultiMediaFiles_LogoId",
                        column: x => x.LogoId,
                        principalSchema: "media",
                        principalTable: "MultiMediaFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MenuMultiMedias",
                schema: "media",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    MenuIconUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuMultiMedias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuMultiMedias_MultiMediaFiles_Id",
                        column: x => x.Id,
                        principalSchema: "media",
                        principalTable: "MultiMediaFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MultiMediaFileLocalizations",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MultiMediaFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultiMediaFileLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultiMediaFileLocalizations_MultiMediaFiles_MultiMediaFileId",
                        column: x => x.MultiMediaFileId,
                        principalSchema: "media",
                        principalTable: "MultiMediaFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtpToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserNature = table.Column<int>(type: "int", nullable: false),
                    ProfileImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_MultiMediaFiles_ProfileImageId",
                        column: x => x.ProfileImageId,
                        principalSchema: "media",
                        principalTable: "MultiMediaFiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleLocalizations",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleLocalizations_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreSliderLocalizations",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    SliderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreSliderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreSliderLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreSliderLocalizations_StoreSliders_StoreSliderId",
                        column: x => x.StoreSliderId,
                        principalSchema: "store_setting",
                        principalTable: "StoreSliders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreSliderMedias",
                schema: "store_setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    StoreSliderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MultiMediaFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreSliderMedias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreSliderMedias_MultiMediaFiles_MultiMediaFileId",
                        column: x => x.MultiMediaFileId,
                        principalSchema: "media",
                        principalTable: "MultiMediaFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreSliderMedias_StoreSliders_StoreSliderId",
                        column: x => x.StoreSliderId,
                        principalSchema: "store_setting",
                        principalTable: "StoreSliders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreTypeLocalizations",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreTypeLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreTypeLocalizations_StoreTypes_StoreTypeId",
                        column: x => x.StoreTypeId,
                        principalSchema: "store_setting",
                        principalTable: "StoreTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TagLocalizations",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagLocalizations_Tags_TagId",
                        column: x => x.TagId,
                        principalSchema: "tag",
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShippingZones",
                schema: "selling_setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    ZoneRegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingZones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingZones_ZoneRegions_ZoneRegionId",
                        column: x => x.ZoneRegionId,
                        principalSchema: "selling_setting",
                        principalTable: "ZoneRegions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ZoneRegionLocalizations",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Region1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZoneRegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZoneRegionLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZoneRegionLocalizations_ZoneRegions_ZoneRegionId",
                        column: x => x.ZoneRegionId,
                        principalSchema: "selling_setting",
                        principalTable: "ZoneRegions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                schema: "base",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    CountryStateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Proviences_CountryStateId",
                        column: x => x.CountryStateId,
                        principalSchema: "base",
                        principalTable: "Proviences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BrandLocalizations",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrandLocalizations_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCards",
                schema: "order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsOpen = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCards_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                schema: "store_setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivationStatus = table.Column<int>(type: "int", nullable: false),
                    StoreTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreIconId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Domain = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stores_MultiMediaFiles_StoreIconId",
                        column: x => x.StoreIconId,
                        principalSchema: "media",
                        principalTable: "MultiMediaFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stores_StoreTypes_StoreTypeId",
                        column: x => x.StoreTypeId,
                        principalSchema: "store_setting",
                        principalTable: "StoreTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stores_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserBussines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BussinessType = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBussines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBussines_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserLocalizations",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLocalizations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShippingZoneLocalizations",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    ZoneName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingZoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingZoneLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingZoneLocalizations_ShippingZones_ShippingZoneId",
                        column: x => x.ShippingZoneId,
                        principalSchema: "selling_setting",
                        principalTable: "ShippingZones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FAQS",
                schema: "store_setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FAQS_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "store_setting",
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MainBusinessSettings",
                schema: "main_setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    SiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Domain = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuperAdministrationEmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewUserDefaultRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeZoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateFormat = table.Column<int>(type: "int", nullable: false),
                    CustomDateFormat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeFormat = table.Column<int>(type: "int", nullable: false),
                    CustomTimeFormat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeekStartOn = table.Column<int>(type: "int", nullable: false),
                    AdminStoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HoldQueueWords = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisallowedCommentKeys = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfCharacteriseToHoldInQueue = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainBusinessSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainBusinessSettings_Countries_TimeZoneId",
                        column: x => x.TimeZoneId,
                        principalSchema: "base",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MainBusinessSettings_Roles_NewUserDefaultRoleId",
                        column: x => x.NewUserDefaultRoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MainBusinessSettings_Stores_AdminStoreId",
                        column: x => x.AdminStoreId,
                        principalSchema: "store_setting",
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PayPalSettings",
                schema: "payment_method",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsEanbled = table.Column<bool>(type: "bit", nullable: false),
                    RequestRetries = table.Column<int>(type: "int", nullable: false),
                    ConnectionTimeout = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientSecret = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayPalSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayPalSettings_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "store_setting",
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                schema: "post",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PublishStatus = table.Column<int>(type: "int", nullable: false),
                    IsSchedulingPublish = table.Column<bool>(type: "bit", nullable: false),
                    PublishOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Visibility = table.Column<int>(type: "int", nullable: false),
                    PostFormat = table.Column<int>(type: "int", nullable: false),
                    PostType = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: true),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false),
                    IsCommentsAllowed = table.Column<bool>(type: "bit", nullable: false),
                    IsAllowPinbacks = table.Column<bool>(type: "bit", nullable: false),
                    WriterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThemeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Revision = table.Column<int>(type: "int", nullable: false),
                    CommentCount = table.Column<int>(type: "int", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    RevisionCount = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Posts_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "post",
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Posts_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "store_setting",
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_Themes_ThemeId",
                        column: x => x.ThemeId,
                        principalSchema: "site_setting",
                        principalTable: "Themes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_Users_WriterId",
                        column: x => x.WriterId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShippingClasses",
                schema: "selling_setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductCount = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingClasses_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "store_setting",
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShippingMethods",
                schema: "selling_setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingMethods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingMethods_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "store_setting",
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShippingOptions",
                schema: "selling_setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    IsEnableShippingCalculatorOnCartPage = table.Column<bool>(type: "bit", nullable: false),
                    HideShippingCostsUntilAddressIsEntered = table.Column<bool>(type: "bit", nullable: false),
                    ShippingDestination = table.Column<int>(type: "int", nullable: false),
                    IsDebugModeEanbled = table.Column<bool>(type: "bit", nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingOptions_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "store_setting",
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreAddresses",
                schema: "store_setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreAddresses_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "base",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreAddresses_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "store_setting",
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreAdmins",
                schema: "store_setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    AdminId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreAdmins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreAdmins_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "store_setting",
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreAdmins_Users_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreDiscussionSettings",
                schema: "store_setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsAllowLinkNotificationsFromOtherBlogs = table.Column<bool>(type: "bit", nullable: false),
                    IsAllowToSubmitCommentsOnNewPosts = table.Column<bool>(type: "bit", nullable: false),
                    IsCommentAuthorMustFillNameAndEmail = table.Column<bool>(type: "bit", nullable: false),
                    IsUsersMustRegisteredAndLoggedInToComment = table.Column<bool>(type: "bit", nullable: false),
                    IsAutomaticallyCloseCommentsOlderThan = table.Column<bool>(type: "bit", nullable: false),
                    CloseCommentOnPostOlderThan = table.Column<int>(type: "int", nullable: true),
                    IsEnableNestedComments = table.Column<bool>(type: "bit", nullable: false),
                    NestedCommentLevels = table.Column<int>(type: "int", nullable: true),
                    IsBreakCommentsIntoPages = table.Column<bool>(type: "bit", nullable: false),
                    NumberOfCommentsIntoPage = table.Column<int>(type: "int", nullable: true),
                    IsProductCommentAllowToRate = table.Column<bool>(type: "bit", nullable: false),
                    IsPostCommentAllowToRate = table.Column<bool>(type: "bit", nullable: false),
                    MaxRate = table.Column<long>(type: "bigint", nullable: false),
                    IsProductCommentAllowToAddMultiMediaFiles = table.Column<bool>(type: "bit", nullable: false),
                    ProductCommentMultiMediaFilesLimit = table.Column<long>(type: "bigint", nullable: false),
                    IsEmailWhenNewPostCreated = table.Column<bool>(type: "bit", nullable: false),
                    IsEmailWhenAnyonePostsComment = table.Column<bool>(type: "bit", nullable: false),
                    IsEmailWhenACommentHeldForModeration = table.Column<bool>(type: "bit", nullable: false),
                    IsCommentMustManuallyApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsCommenAuthorMustHavePreviouslyApprovedComment = table.Column<bool>(type: "bit", nullable: false),
                    NumberOfCharacteriseToHoldInQueue = table.Column<int>(type: "int", nullable: false),
                    HoldQueueWords = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisallowedCommentKeys = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreDiscussionSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreDiscussionSettings_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "store_setting",
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreGeneralSellingSettings",
                schema: "selling_setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WeightUnit = table.Column<int>(type: "int", nullable: false),
                    DimensionsUnit = table.Column<int>(type: "int", nullable: false),
                    IsEnableStarRatingOnProductReviews = table.Column<bool>(type: "bit", nullable: false),
                    IsProductStarRatingsRequired = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreGeneralSellingSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreGeneralSellingSettings_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "base",
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreGeneralSellingSettings_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "store_setting",
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreGeneralSettings",
                schema: "store_setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreSubDomian = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreSubDomianUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreIconId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TimeZoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateFormat = table.Column<int>(type: "int", nullable: false),
                    CustomDateFormat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeFormat = table.Column<int>(type: "int", nullable: false),
                    CustomTimeFormat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeekStartOn = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreGeneralSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreGeneralSettings_Countries_TimeZoneId",
                        column: x => x.TimeZoneId,
                        principalSchema: "base",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreGeneralSettings_MultiMediaFiles_StoreIconId",
                        column: x => x.StoreIconId,
                        principalSchema: "media",
                        principalTable: "MultiMediaFiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StoreGeneralSettings_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "store_setting",
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreGroups",
                schema: "store_setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreGroups_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "store_setting",
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreInventorySettings",
                schema: "selling_setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsEnableStockManagement = table.Column<bool>(type: "bit", nullable: false),
                    HoldStockInMinutes = table.Column<int>(type: "int", nullable: false),
                    IsLowStockNotificationsEnable = table.Column<bool>(type: "bit", nullable: false),
                    IsOutOfStockNotificationsEnable = table.Column<bool>(type: "bit", nullable: false),
                    NotificationRecipientEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LowStockThreshold = table.Column<int>(type: "int", nullable: false),
                    OutOfStockThreshold = table.Column<int>(type: "int", nullable: false),
                    IsOutOfStockHideFromCatalog = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreInventorySettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreInventorySettings_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "store_setting",
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreLocalizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreLocalizations_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "store_setting",
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreLowThresoldNotificationManagmentSettings",
                schema: "store_setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LowThresoldLimit = table.Column<long>(type: "bigint", nullable: false),
                    NotificationType = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreLowThresoldNotificationManagmentSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreLowThresoldNotificationManagmentSettings_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "store_setting",
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreMediaOptionSettings",
                schema: "store_setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThumbnailWidth = table.Column<int>(type: "int", nullable: true),
                    ThumbnailHeight = table.Column<int>(type: "int", nullable: true),
                    UseThumbnailDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsCropThumbnailToExactDimensions = table.Column<bool>(type: "bit", nullable: true),
                    MediumSizeMaxWidth = table.Column<int>(type: "int", nullable: true),
                    MediumSizeMaxHeight = table.Column<int>(type: "int", nullable: true),
                    UseMediumSizeDefault = table.Column<bool>(type: "bit", nullable: false),
                    LargeSizeMaxWidth = table.Column<int>(type: "int", nullable: true),
                    LargeSizeMaxHeight = table.Column<int>(type: "int", nullable: true),
                    UseLargeSizeDefault = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreMediaOptionSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreMediaOptionSettings_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "store_setting",
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ZarinPalSettings",
                schema: "payment_method",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsEanbled = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZarinPalSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZarinPalSettings_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "store_setting",
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FAQLocalizations",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FAQId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FAQLocalizations_FAQS_FAQId",
                        column: x => x.FAQId,
                        principalSchema: "store_setting",
                        principalTable: "FAQS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MainBusinessSettingLocalizations",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    MainBussimnessSettingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SiteTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tagline = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainBusinessSettingLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainBusinessSettingLocalizations_MainBusinessSettings_MainBussimnessSettingId",
                        column: x => x.MainBussimnessSettingId,
                        principalSchema: "main_setting",
                        principalTable: "MainBusinessSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PayPalSettingLocalizations",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Mode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PayPalSettingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayPalSettingLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayPalSettingLocalizations_PayPalSettings_PayPalSettingId",
                        column: x => x.PayPalSettingId,
                        principalSchema: "payment_method",
                        principalTable: "PayPalSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostCategories",
                schema: "post",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "product",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostCategories_Posts_PostId",
                        column: x => x.PostId,
                        principalSchema: "post",
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostContents",
                schema: "content",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContentType = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    ContentAllowingStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostContents_Posts_PostId",
                        column: x => x.PostId,
                        principalSchema: "post",
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostLocalizations",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostLocalizations_Posts_PostId",
                        column: x => x.PostId,
                        principalSchema: "post",
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostMultimedias",
                schema: "media",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsIndex = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostMultimedias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostMultimedias_MultiMediaFiles_Id",
                        column: x => x.Id,
                        principalSchema: "media",
                        principalTable: "MultiMediaFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostMultimedias_Posts_PostId",
                        column: x => x.PostId,
                        principalSchema: "post",
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostRates",
                schema: "rate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostRates_Posts_PostId",
                        column: x => x.PostId,
                        principalSchema: "post",
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostRates_Rates_RateId",
                        column: x => x.RateId,
                        principalTable: "Rates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostTags",
                schema: "tag",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostTags_Posts_PostId",
                        column: x => x.PostId,
                        principalSchema: "post",
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostTags_Tags_TagId",
                        column: x => x.TagId,
                        principalSchema: "tag",
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreReadingSettings",
                schema: "store_setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HomepageDisplay = table.Column<int>(type: "int", nullable: false),
                    HomePageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PostsPageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BlogPagesShowAtMost = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreReadingSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreReadingSettings_Posts_HomePageId",
                        column: x => x.HomePageId,
                        principalSchema: "post",
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StoreReadingSettings_Posts_PostsPageId",
                        column: x => x.PostsPageId,
                        principalSchema: "post",
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StoreReadingSettings_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "store_setting",
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductType = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsOrginalProduct = table.Column<bool>(type: "bit", nullable: false),
                    GeneralCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishStatus = table.Column<int>(type: "int", nullable: false),
                    Visibility = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSchedulingPublish = table.Column<bool>(type: "bit", nullable: false),
                    PublishOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CatalogVisibility = table.Column<int>(type: "int", nullable: false),
                    ProductSellingUnit = table.Column<int>(type: "int", nullable: false),
                    IsInstallmentEnabled = table.Column<bool>(type: "bit", nullable: false),
                    PackingLength = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PackingWidth = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PackingHeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ProductLength = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ProductWidth = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ProductHeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsManageStock = table.Column<bool>(type: "bit", nullable: false),
                    StockStatus = table.Column<int>(type: "int", nullable: false),
                    StockQuantity = table.Column<long>(type: "bigint", nullable: true),
                    AllowBackordersStatus = table.Column<int>(type: "int", nullable: false),
                    LowStockThreshold = table.Column<long>(type: "bigint", nullable: false),
                    ShippingClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MenuOrder = table.Column<long>(type: "bigint", nullable: true),
                    IsCommentsAllowed = table.Column<bool>(type: "bit", nullable: false),
                    TotalRate = table.Column<byte>(type: "tinyint", nullable: false),
                    SelledQuantity = table.Column<long>(type: "bigint", nullable: false),
                    CommentCount = table.Column<long>(type: "bigint", nullable: false),
                    ViewCount = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_ShippingClasses_ShippingClassId",
                        column: x => x.ShippingClassId,
                        principalSchema: "selling_setting",
                        principalTable: "ShippingClasses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "store_setting",
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShippingClassLocalizations",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingClassLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingClassLocalizations_ShippingClasses_ShippingClassId",
                        column: x => x.ShippingClassId,
                        principalSchema: "selling_setting",
                        principalTable: "ShippingClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShippingMethodLocalizations",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    MethodTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingMethodLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingMethodLocalizations_ShippingMethods_ShippingMethodId",
                        column: x => x.ShippingMethodId,
                        principalSchema: "selling_setting",
                        principalTable: "ShippingMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreAddressLocalizations",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreAddressLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreAddressLocalizations_StoreAddresses_StoreAddressId",
                        column: x => x.StoreAddressId,
                        principalSchema: "store_setting",
                        principalTable: "StoreAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreGeneralSettingLocalizations",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreGeneralSettingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreGeneralSettingLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreGeneralSettingLocalizations_StoreGeneralSettings_StoreGeneralSettingId",
                        column: x => x.StoreGeneralSettingId,
                        principalSchema: "store_setting",
                        principalTable: "StoreGeneralSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreGroupLocalizations",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreGroupLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreGroupLocalizations_StoreGroups_StoreGroupId",
                        column: x => x.StoreGroupId,
                        principalSchema: "store_setting",
                        principalTable: "StoreGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreUserGroups",
                schema: "store_setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    StoreGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreUserGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreUserGroups_StoreGroups_StoreGroupId",
                        column: x => x.StoreGroupId,
                        principalSchema: "store_setting",
                        principalTable: "StoreGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreUserGroups_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ZarinPalSettingLocalizations",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    MerchentCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZarinPalSettingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZarinPalSettingLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZarinPalSettingLocalizations_ZarinPalSettings_ZarinPalSettingId",
                        column: x => x.ZarinPalSettingId,
                        principalSchema: "payment_method",
                        principalTable: "ZarinPalSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreWritingSettings",
                schema: "store_setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DefaultPostCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DefaultPostFormat = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreWritingSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreWritingSettings_PostCategories_DefaultPostCategoryId",
                        column: x => x.DefaultPostCategoryId,
                        principalSchema: "post",
                        principalTable: "PostCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreWritingSettings_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "store_setting",
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostContentLocalizations",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    ContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Excerpt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostContentLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostContentLocalizations_PostContents_ContentId",
                        column: x => x.ContentId,
                        principalSchema: "content",
                        principalTable: "PostContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostMultimediaLocalizations",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostMultimediaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostMultimediaLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostMultimediaLocalizations_MultiMediaFileLocalizations_Id",
                        column: x => x.Id,
                        principalSchema: "localization",
                        principalTable: "MultiMediaFileLocalizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostMultimediaLocalizations_PostMultimedias_PostMultimediaId",
                        column: x => x.PostMultimediaId,
                        principalSchema: "media",
                        principalTable: "PostMultimedias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                schema: "comment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    CommentStatus = table.Column<int>(type: "int", nullable: false),
                    AuthorEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsCommentUsefullCount = table.Column<int>(type: "int", nullable: false),
                    IsCommentNotUsefullCount = table.Column<int>(type: "int", nullable: false),
                    ReplyedToCommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsBuyer = table.Column<bool>(type: "bit", nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_ReplyedToCommentId",
                        column: x => x.ReplyedToCommentId,
                        principalSchema: "comment",
                        principalTable: "Comments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalSchema: "post",
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "product",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Coupons",
                schema: "selling",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountType = table.Column<int>(type: "int", nullable: false),
                    Percent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValidFrom = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ValidTo = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsableCount = table.Column<int>(type: "int", nullable: false),
                    Usage = table.Column<int>(type: "int", nullable: false),
                    MinInvoiceLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxInvoiceLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coupons_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "product",
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Coupons_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "store_setting",
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Coupons_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                schema: "site_setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuType = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    MenuIconId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PostCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_MenuMultiMedias_MenuIconId",
                        column: x => x.MenuIconId,
                        principalSchema: "media",
                        principalTable: "MenuMultiMedias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menus_PostCategories_PostCategoryId",
                        column: x => x.PostCategoryId,
                        principalSchema: "post",
                        principalTable: "PostCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Menus_Posts_PostId",
                        column: x => x.PostId,
                        principalSchema: "post",
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Menus_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "product",
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Menus_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "store_setting",
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                schema: "product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "product",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "product",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductContents",
                schema: "content",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContentType = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    ContentAllowingStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductContents_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "product",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductInstallments",
                schema: "product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberOfInstallment = table.Column<long>(type: "bigint", nullable: false),
                    BenefitPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInstallments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductInstallments_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "product",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductLocalizations",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    PurchaseNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PackingDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductLocalizations_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "product",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductMultiMedias",
                schema: "media",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsIndex = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMultiMedias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductMultiMedias_MultiMediaFiles_Id",
                        column: x => x.Id,
                        principalSchema: "media",
                        principalTable: "MultiMediaFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductMultiMedias_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "product",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductRates",
                schema: "rate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductRates_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "product",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductRates_Rates_RateId",
                        column: x => x.RateId,
                        principalTable: "Rates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductSpecialOffers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfferPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Expiration = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSpecialOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSpecialOffers_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "product",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductTags",
                schema: "tag",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTags_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "product",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductTags_Tags_TagId",
                        column: x => x.TagId,
                        principalSchema: "tag",
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCardDetails",
                schema: "order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ShoppingCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsInstallmentPayment = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCardDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCardDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "product",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShoppingCardDetails_ShoppingCards_ShoppingCardId",
                        column: x => x.ShoppingCardId,
                        principalSchema: "order",
                        principalTable: "ShoppingCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommentLocalizations",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentLocalizations_Comments_CommentId",
                        column: x => x.CommentId,
                        principalSchema: "comment",
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommentMultiMedias",
                schema: "media",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentMultiMedias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentMultiMedias_Comments_CommentId",
                        column: x => x.CommentId,
                        principalSchema: "comment",
                        principalTable: "Comments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CommentMultiMedias_MultiMediaFiles_Id",
                        column: x => x.Id,
                        principalSchema: "media",
                        principalTable: "MultiMediaFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentPosetiveNegativePoints",
                schema: "comment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PointComment = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentPosetiveNegativePoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentPosetiveNegativePoints_Comments_CommentId",
                        column: x => x.CommentId,
                        principalSchema: "comment",
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommentRates",
                schema: "rate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentRates_Comments_CommentId",
                        column: x => x.CommentId,
                        principalSchema: "comment",
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommentRates_Rates_RateId",
                        column: x => x.RateId,
                        principalTable: "Rates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CouponLocalizations",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CouponId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CouponLocalizations_Coupons_CouponId",
                        column: x => x.CouponId,
                        principalSchema: "selling",
                        principalTable: "Coupons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                schema: "order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    OrderAction = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShoppingCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CouponId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    PaidOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Coupons_CouponId",
                        column: x => x.CouponId,
                        principalSchema: "selling",
                        principalTable: "Coupons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Invoices_ShoppingCards_ShoppingCardId",
                        column: x => x.ShoppingCardId,
                        principalSchema: "order",
                        principalTable: "ShoppingCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MenuLocalizations",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuLocalizations_Menus_MenuId",
                        column: x => x.MenuId,
                        principalSchema: "site_setting",
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductContentLocalizations",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    ContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductContentLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductContentLocalizations_ProductContents_ContentId",
                        column: x => x.ContentId,
                        principalSchema: "content",
                        principalTable: "ProductContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductMultiMediaLocalizations",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductMultiMediaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMultiMediaLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductMultiMediaLocalizations_MultiMediaFileLocalizations_Id",
                        column: x => x.Id,
                        principalSchema: "localization",
                        principalTable: "MultiMediaFileLocalizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductMultiMediaLocalizations_ProductMultiMedias_ProductMultiMediaId",
                        column: x => x.ProductMultiMediaId,
                        principalSchema: "media",
                        principalTable: "ProductMultiMedias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommentPosetiveNegativePointLocalizations",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    CommentPoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentPosetiveNegativePointId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentPosetiveNegativePointLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentPosetiveNegativePointLocalizations_CommentPosetiveNegativePoints_CommentPosetiveNegativePointId",
                        column: x => x.CommentPosetiveNegativePointId,
                        principalSchema: "comment",
                        principalTable: "CommentPosetiveNegativePoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceLocalizations",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    CustomerAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerProvidedNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceLocalizations_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "order",
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderNotes",
                schema: "order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    OrderNoteType = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderNotes_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "order",
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderNotes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderTrackings",
                schema: "order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    OrderTracingStatus = table.Column<int>(type: "int", nullable: false),
                    OrderNoteType = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTrackings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderTrackings_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "order",
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PspSadadLogs",
                schema: "payment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Number = table.Column<long>(type: "bigint", nullable: false),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MerchantId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResCodePaymentRequest = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResCodePaymentVerify = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentRequestedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    BackFromBankOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    VerifyRequestedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    VerifiedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    PaymentSuccessful = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PspSadadLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PspSadadLogs_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "order",
                        principalTable: "Invoices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderNoteLocalizations",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderNoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderNoteLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderNoteLocalizations_OrderNotes_OrderNoteId",
                        column: x => x.OrderNoteId,
                        principalSchema: "order",
                        principalTable: "OrderNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderTrackingLocalizations",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderTrackingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTrackingLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderTrackingLocalizations_OrderTrackings_OrderTrackingId",
                        column: x => x.OrderTrackingId,
                        principalSchema: "order",
                        principalTable: "OrderTrackings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DiscountPrices",
                schema: "product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VariableProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalePriceFrom = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    SalePriceTo = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscountPrices_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "product",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DownloadableFileLocalizations",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DownloadableFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DownloadableFileLocalizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DownloadableFiles",
                schema: "product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VariableProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DownloadableFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DownloadableFiles_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "product",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VariableProducts",
                schema: "product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    DownloadableFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsManageStock = table.Column<bool>(type: "bit", nullable: false),
                    ShippingClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariableProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VariableProducts_DownloadableFiles_DownloadableFileId",
                        column: x => x.DownloadableFileId,
                        principalSchema: "product",
                        principalTable: "DownloadableFiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VariableProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "product",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VariableProducts_ShippingClasses_ShippingClassId",
                        column: x => x.ShippingClassId,
                        principalSchema: "selling_setting",
                        principalTable: "ShippingClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                schema: "product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VariableProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prices_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "product",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prices_VariableProducts_VariableProductId",
                        column: x => x.VariableProductId,
                        principalSchema: "product",
                        principalTable: "VariableProducts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VariableProductLocalizations",
                schema: "localization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VariableProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariableProductLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VariableProductLocalizations_VariableProducts_VariableProductId",
                        column: x => x.VariableProductId,
                        principalSchema: "product",
                        principalTable: "VariableProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstallmentInvoices",
                schema: "order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    ShoppingCardDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstallmentNumber = table.Column<long>(type: "bigint", nullable: false),
                    PriceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Payable = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsPayed = table.Column<bool>(type: "bit", nullable: false),
                    PaidOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstallmentInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstallmentInvoices_Prices_PriceId",
                        column: x => x.PriceId,
                        principalSchema: "product",
                        principalTable: "Prices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstallmentInvoices_ShoppingCardDetails_ShoppingCardDetailId",
                        column: x => x.ShoppingCardDetailId,
                        principalSchema: "order",
                        principalTable: "ShoppingCardDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrandLocalizations_BrandId",
                schema: "localization",
                table: "BrandLocalizations",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_LogoId",
                table: "Brands",
                column: "LogoId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                schema: "product",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryLocalizations_CategoryId",
                schema: "localization",
                table: "CategoryLocalizations",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryStateId",
                schema: "base",
                table: "Cities",
                column: "CountryStateId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentLocalizations_CommentId",
                schema: "localization",
                table: "CommentLocalizations",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentMultiMedias_CommentId",
                schema: "media",
                table: "CommentMultiMedias",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentPosetiveNegativePointLocalizations_CommentPosetiveNegativePointId",
                schema: "localization",
                table: "CommentPosetiveNegativePointLocalizations",
                column: "CommentPosetiveNegativePointId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentPosetiveNegativePoints_CommentId",
                schema: "comment",
                table: "CommentPosetiveNegativePoints",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentRates_CommentId",
                schema: "rate",
                table: "CommentRates",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentRates_RateId",
                schema: "rate",
                table: "CommentRates",
                column: "RateId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                schema: "comment",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductId",
                schema: "comment",
                table: "Comments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ReplyedToCommentId",
                schema: "comment",
                table: "Comments",
                column: "ReplyedToCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                schema: "comment",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CouponLocalizations_CouponId",
                schema: "localization",
                table: "CouponLocalizations",
                column: "CouponId");

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_ProductId",
                schema: "selling",
                table: "Coupons",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_StoreId",
                schema: "selling",
                table: "Coupons",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_UserId",
                schema: "selling",
                table: "Coupons",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyLocalizations_CurrencyId",
                schema: "localization",
                table: "CurrencyLocalizations",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountPrices_ProductId",
                schema: "product",
                table: "DiscountPrices",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountPrices_VariableProductId",
                schema: "product",
                table: "DiscountPrices",
                column: "VariableProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DownloadableFileLocalizations_DownloadableFileId",
                schema: "localization",
                table: "DownloadableFileLocalizations",
                column: "DownloadableFileId");

            migrationBuilder.CreateIndex(
                name: "IX_DownloadableFiles_ProductId",
                schema: "product",
                table: "DownloadableFiles",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DownloadableFiles_VariableProductId",
                schema: "product",
                table: "DownloadableFiles",
                column: "VariableProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FAQLocalizations_FAQId",
                schema: "localization",
                table: "FAQLocalizations",
                column: "FAQId");

            migrationBuilder.CreateIndex(
                name: "IX_FAQS_StoreId",
                schema: "store_setting",
                table: "FAQS",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_InstallmentInvoices_PriceId",
                schema: "order",
                table: "InstallmentInvoices",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_InstallmentInvoices_ShoppingCardDetailId",
                schema: "order",
                table: "InstallmentInvoices",
                column: "ShoppingCardDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLocalizations_InvoiceId",
                schema: "localization",
                table: "InvoiceLocalizations",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CouponId",
                schema: "order",
                table: "Invoices",
                column: "CouponId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ShoppingCardId",
                schema: "order",
                table: "Invoices",
                column: "ShoppingCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_UserId",
                schema: "order",
                table: "Invoices",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MainBusinessSettingLocalizations_MainBussimnessSettingId",
                schema: "localization",
                table: "MainBusinessSettingLocalizations",
                column: "MainBussimnessSettingId");

            migrationBuilder.CreateIndex(
                name: "IX_MainBusinessSettings_AdminStoreId",
                schema: "main_setting",
                table: "MainBusinessSettings",
                column: "AdminStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_MainBusinessSettings_NewUserDefaultRoleId",
                schema: "main_setting",
                table: "MainBusinessSettings",
                column: "NewUserDefaultRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_MainBusinessSettings_TimeZoneId",
                schema: "main_setting",
                table: "MainBusinessSettings",
                column: "TimeZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuLocalizations_MenuId",
                schema: "localization",
                table: "MenuLocalizations",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_MenuIconId",
                schema: "site_setting",
                table: "Menus",
                column: "MenuIconId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_PostCategoryId",
                schema: "site_setting",
                table: "Menus",
                column: "PostCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_PostId",
                schema: "site_setting",
                table: "Menus",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_ProductId",
                schema: "site_setting",
                table: "Menus",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_StoreId",
                schema: "site_setting",
                table: "Menus",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_MultiMediaFileLocalizations_MultiMediaFileId",
                schema: "localization",
                table: "MultiMediaFileLocalizations",
                column: "MultiMediaFileId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderNoteLocalizations_OrderNoteId",
                schema: "localization",
                table: "OrderNoteLocalizations",
                column: "OrderNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderNotes_InvoiceId",
                schema: "order",
                table: "OrderNotes",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderNotes_UserId",
                schema: "order",
                table: "OrderNotes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTrackingLocalizations_OrderTrackingId",
                schema: "localization",
                table: "OrderTrackingLocalizations",
                column: "OrderTrackingId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTrackings_InvoiceId",
                schema: "order",
                table: "OrderTrackings",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_PayPalSettingLocalizations_PayPalSettingId",
                schema: "localization",
                table: "PayPalSettingLocalizations",
                column: "PayPalSettingId");

            migrationBuilder.CreateIndex(
                name: "IX_PayPalSettings_StoreId",
                schema: "payment_method",
                table: "PayPalSettings",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategories_CategoryId",
                schema: "post",
                table: "PostCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategories_PostId",
                schema: "post",
                table: "PostCategories",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostContentLocalizations_ContentId",
                schema: "localization",
                table: "PostContentLocalizations",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_PostContents_PostId",
                schema: "content",
                table: "PostContents",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostLocalizations_PostId",
                schema: "localization",
                table: "PostLocalizations",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostMultimediaLocalizations_PostMultimediaId",
                schema: "localization",
                table: "PostMultimediaLocalizations",
                column: "PostMultimediaId");

            migrationBuilder.CreateIndex(
                name: "IX_PostMultimedias_PostId",
                schema: "media",
                table: "PostMultimedias",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostRates_PostId",
                schema: "rate",
                table: "PostRates",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostRates_RateId",
                schema: "rate",
                table: "PostRates",
                column: "RateId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ParentId",
                schema: "post",
                table: "Posts",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_StoreId",
                schema: "post",
                table: "Posts",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ThemeId",
                schema: "post",
                table: "Posts",
                column: "ThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_WriterId",
                schema: "post",
                table: "Posts",
                column: "WriterId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_PostId",
                schema: "tag",
                table: "PostTags",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_TagId",
                schema: "tag",
                table: "PostTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_ProductId",
                schema: "product",
                table: "Prices",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_VariableProductId",
                schema: "product",
                table: "Prices",
                column: "VariableProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                schema: "product",
                table: "ProductCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ProductId",
                schema: "product",
                table: "ProductCategories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductContentLocalizations_ContentId",
                schema: "localization",
                table: "ProductContentLocalizations",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductContents_ProductId",
                schema: "content",
                table: "ProductContents",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInstallments_ProductId",
                schema: "product",
                table: "ProductInstallments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLocalizations_ProductId",
                schema: "localization",
                table: "ProductLocalizations",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMultiMediaLocalizations_ProductMultiMediaId",
                schema: "localization",
                table: "ProductMultiMediaLocalizations",
                column: "ProductMultiMediaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMultiMedias_ProductId",
                schema: "media",
                table: "ProductMultiMedias",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRates_ProductId",
                schema: "rate",
                table: "ProductRates",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRates_RateId",
                schema: "rate",
                table: "ProductRates",
                column: "RateId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                schema: "product",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShippingClassId",
                schema: "product",
                table: "Products",
                column: "ShippingClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StoreId",
                schema: "product",
                table: "Products",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSpecialOffers_ProductId",
                table: "ProductSpecialOffers",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTags_ProductId",
                schema: "tag",
                table: "ProductTags",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTags_TagId",
                schema: "tag",
                table: "ProductTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Proviences_CountryId",
                schema: "base",
                table: "Proviences",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PspSadadLogs_InvoiceId",
                schema: "payment",
                table: "PspSadadLogs",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleLocalizations_RoleId",
                schema: "localization",
                table: "RoleLocalizations",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingClasses_StoreId",
                schema: "selling_setting",
                table: "ShippingClasses",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingClassLocalizations_ShippingClassId",
                schema: "localization",
                table: "ShippingClassLocalizations",
                column: "ShippingClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingMethodLocalizations_ShippingMethodId",
                schema: "localization",
                table: "ShippingMethodLocalizations",
                column: "ShippingMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingMethods_StoreId",
                schema: "selling_setting",
                table: "ShippingMethods",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingOptions_StoreId",
                schema: "selling_setting",
                table: "ShippingOptions",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingZoneLocalizations_ShippingZoneId",
                schema: "localization",
                table: "ShippingZoneLocalizations",
                column: "ShippingZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingZones_ZoneRegionId",
                schema: "selling_setting",
                table: "ShippingZones",
                column: "ZoneRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCardDetails_ProductId",
                schema: "order",
                table: "ShoppingCardDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCardDetails_ShoppingCardId",
                schema: "order",
                table: "ShoppingCardDetails",
                column: "ShoppingCardId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCards_UserId",
                schema: "order",
                table: "ShoppingCards",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreAddresses_CityId",
                schema: "store_setting",
                table: "StoreAddresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreAddresses_StoreId",
                schema: "store_setting",
                table: "StoreAddresses",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreAddressLocalizations_StoreAddressId",
                schema: "localization",
                table: "StoreAddressLocalizations",
                column: "StoreAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreAdmins_AdminId",
                schema: "store_setting",
                table: "StoreAdmins",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreAdmins_StoreId",
                schema: "store_setting",
                table: "StoreAdmins",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreDiscussionSettings_StoreId",
                schema: "store_setting",
                table: "StoreDiscussionSettings",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreGeneralSellingSettings_CurrencyId",
                schema: "selling_setting",
                table: "StoreGeneralSellingSettings",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreGeneralSellingSettings_StoreId",
                schema: "selling_setting",
                table: "StoreGeneralSellingSettings",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreGeneralSettingLocalizations_StoreGeneralSettingId",
                schema: "localization",
                table: "StoreGeneralSettingLocalizations",
                column: "StoreGeneralSettingId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreGeneralSettings_StoreIconId",
                schema: "store_setting",
                table: "StoreGeneralSettings",
                column: "StoreIconId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreGeneralSettings_StoreId",
                schema: "store_setting",
                table: "StoreGeneralSettings",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreGeneralSettings_TimeZoneId",
                schema: "store_setting",
                table: "StoreGeneralSettings",
                column: "TimeZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreGroupLocalizations_StoreGroupId",
                schema: "localization",
                table: "StoreGroupLocalizations",
                column: "StoreGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreGroups_StoreId",
                schema: "store_setting",
                table: "StoreGroups",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreInventorySettings_StoreId",
                schema: "selling_setting",
                table: "StoreInventorySettings",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreLocalizations_StoreId",
                table: "StoreLocalizations",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreLowThresoldNotificationManagmentSettings_StoreId",
                schema: "store_setting",
                table: "StoreLowThresoldNotificationManagmentSettings",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreMediaOptionSettings_StoreId",
                schema: "store_setting",
                table: "StoreMediaOptionSettings",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreReadingSettings_HomePageId",
                schema: "store_setting",
                table: "StoreReadingSettings",
                column: "HomePageId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreReadingSettings_PostsPageId",
                schema: "store_setting",
                table: "StoreReadingSettings",
                column: "PostsPageId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreReadingSettings_StoreId",
                schema: "store_setting",
                table: "StoreReadingSettings",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_OwnerId",
                schema: "store_setting",
                table: "Stores",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_StoreIconId",
                schema: "store_setting",
                table: "Stores",
                column: "StoreIconId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_StoreTypeId",
                schema: "store_setting",
                table: "Stores",
                column: "StoreTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreSliderLocalizations_StoreSliderId",
                schema: "localization",
                table: "StoreSliderLocalizations",
                column: "StoreSliderId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreSliderMedias_MultiMediaFileId",
                schema: "store_setting",
                table: "StoreSliderMedias",
                column: "MultiMediaFileId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreSliderMedias_StoreSliderId",
                schema: "store_setting",
                table: "StoreSliderMedias",
                column: "StoreSliderId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreTypeLocalizations_StoreTypeId",
                schema: "localization",
                table: "StoreTypeLocalizations",
                column: "StoreTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreUserGroups_StoreGroupId",
                schema: "store_setting",
                table: "StoreUserGroups",
                column: "StoreGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreUserGroups_UserId",
                schema: "store_setting",
                table: "StoreUserGroups",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreWritingSettings_DefaultPostCategoryId",
                schema: "store_setting",
                table: "StoreWritingSettings",
                column: "DefaultPostCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreWritingSettings_StoreId",
                schema: "store_setting",
                table: "StoreWritingSettings",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_TagLocalizations_TagId",
                schema: "localization",
                table: "TagLocalizations",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBussines_UserId",
                table: "UserBussines",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLocalizations_UserId",
                schema: "localization",
                table: "UserLocalizations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProfileImageId",
                table: "Users",
                column: "ProfileImageId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VariableProductLocalizations_VariableProductId",
                schema: "localization",
                table: "VariableProductLocalizations",
                column: "VariableProductId");

            migrationBuilder.CreateIndex(
                name: "IX_VariableProducts_DownloadableFileId",
                schema: "product",
                table: "VariableProducts",
                column: "DownloadableFileId");

            migrationBuilder.CreateIndex(
                name: "IX_VariableProducts_ProductId",
                schema: "product",
                table: "VariableProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_VariableProducts_ShippingClassId",
                schema: "product",
                table: "VariableProducts",
                column: "ShippingClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ZarinPalSettingLocalizations_ZarinPalSettingId",
                schema: "localization",
                table: "ZarinPalSettingLocalizations",
                column: "ZarinPalSettingId");

            migrationBuilder.CreateIndex(
                name: "IX_ZarinPalSettings_StoreId",
                schema: "payment_method",
                table: "ZarinPalSettings",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ZoneRegionLocalizations_ZoneRegionId",
                schema: "localization",
                table: "ZoneRegionLocalizations",
                column: "ZoneRegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountPrices_VariableProducts_VariableProductId",
                schema: "product",
                table: "DiscountPrices",
                column: "VariableProductId",
                principalSchema: "product",
                principalTable: "VariableProducts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DownloadableFileLocalizations_DownloadableFiles_DownloadableFileId",
                schema: "localization",
                table: "DownloadableFileLocalizations",
                column: "DownloadableFileId",
                principalSchema: "product",
                principalTable: "DownloadableFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DownloadableFiles_VariableProducts_VariableProductId",
                schema: "product",
                table: "DownloadableFiles",
                column: "VariableProductId",
                principalSchema: "product",
                principalTable: "VariableProducts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                schema: "product",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_MultiMediaFiles_StoreIconId",
                schema: "store_setting",
                table: "Stores");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_MultiMediaFiles_ProfileImageId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_DownloadableFiles_Products_ProductId",
                schema: "product",
                table: "DownloadableFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_VariableProducts_Products_ProductId",
                schema: "product",
                table: "VariableProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Users_OwnerId",
                schema: "store_setting",
                table: "Stores");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingClasses_Stores_StoreId",
                schema: "selling_setting",
                table: "ShippingClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_DownloadableFiles_VariableProducts_VariableProductId",
                schema: "product",
                table: "DownloadableFiles");

            migrationBuilder.DropTable(
                name: "BrandLocalizations",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "CategoryLocalizations",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "CommentLocalizations",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "CommentMultiMedias",
                schema: "media");

            migrationBuilder.DropTable(
                name: "CommentPosetiveNegativePointLocalizations",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "CommentRates",
                schema: "rate");

            migrationBuilder.DropTable(
                name: "CouponLocalizations",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "CurrencyLocalizations",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "DiscountPrices",
                schema: "product");

            migrationBuilder.DropTable(
                name: "DownloadableFileLocalizations",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "FAQLocalizations",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "InstallmentInvoices",
                schema: "order");

            migrationBuilder.DropTable(
                name: "InvoiceLocalizations",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "Languages",
                schema: "base");

            migrationBuilder.DropTable(
                name: "MainBusinessSettingLocalizations",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "MainStoreMediaOptionSettings");

            migrationBuilder.DropTable(
                name: "MenuLocalizations",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "OrderNoteLocalizations",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "OrderTrackingLocalizations",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "PayPalSettingLocalizations",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "PostContentLocalizations",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "PostLocalizations",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "PostMultimediaLocalizations",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "PostRates",
                schema: "rate");

            migrationBuilder.DropTable(
                name: "PostTags",
                schema: "tag");

            migrationBuilder.DropTable(
                name: "ProductCategories",
                schema: "product");

            migrationBuilder.DropTable(
                name: "ProductContentLocalizations",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "ProductInstallments",
                schema: "product");

            migrationBuilder.DropTable(
                name: "ProductLocalizations",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "ProductMultiMediaLocalizations",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "ProductRates",
                schema: "rate");

            migrationBuilder.DropTable(
                name: "ProductSpecialOffers");

            migrationBuilder.DropTable(
                name: "ProductTags",
                schema: "tag");

            migrationBuilder.DropTable(
                name: "PspSadadLogs",
                schema: "payment");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "RoleLocalizations",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "ShippingClassLocalizations",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "ShippingMethodLocalizations",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "ShippingOptions",
                schema: "selling_setting");

            migrationBuilder.DropTable(
                name: "ShippingZoneLocalizations",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "StoreAddressLocalizations",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "StoreAdmins",
                schema: "store_setting");

            migrationBuilder.DropTable(
                name: "StoreDiscussionSettings",
                schema: "store_setting");

            migrationBuilder.DropTable(
                name: "StoreGeneralSellingSettings",
                schema: "selling_setting");

            migrationBuilder.DropTable(
                name: "StoreGeneralSettingLocalizations",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "StoreGroupLocalizations",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "StoreInventorySettings",
                schema: "selling_setting");

            migrationBuilder.DropTable(
                name: "StoreLocalizations");

            migrationBuilder.DropTable(
                name: "StoreLowThresoldNotificationManagmentSettings",
                schema: "store_setting");

            migrationBuilder.DropTable(
                name: "StoreMediaOptionSettings",
                schema: "store_setting");

            migrationBuilder.DropTable(
                name: "StoreReadingSettings",
                schema: "store_setting");

            migrationBuilder.DropTable(
                name: "StoreSliderLocalizations",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "StoreSliderMedias",
                schema: "store_setting");

            migrationBuilder.DropTable(
                name: "StoreTypeLocalizations",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "StoreUserGroups",
                schema: "store_setting");

            migrationBuilder.DropTable(
                name: "StoreWritingSettings",
                schema: "store_setting");

            migrationBuilder.DropTable(
                name: "TagLocalizations",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "UserBussines");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLocalizations",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "VariableProductLocalizations",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "ZarinPalSettingLocalizations",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "ZoneRegionLocalizations",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "CommentPosetiveNegativePoints",
                schema: "comment");

            migrationBuilder.DropTable(
                name: "FAQS",
                schema: "store_setting");

            migrationBuilder.DropTable(
                name: "Prices",
                schema: "product");

            migrationBuilder.DropTable(
                name: "ShoppingCardDetails",
                schema: "order");

            migrationBuilder.DropTable(
                name: "MainBusinessSettings",
                schema: "main_setting");

            migrationBuilder.DropTable(
                name: "Menus",
                schema: "site_setting");

            migrationBuilder.DropTable(
                name: "OrderNotes",
                schema: "order");

            migrationBuilder.DropTable(
                name: "OrderTrackings",
                schema: "order");

            migrationBuilder.DropTable(
                name: "PayPalSettings",
                schema: "payment_method");

            migrationBuilder.DropTable(
                name: "PostContents",
                schema: "content");

            migrationBuilder.DropTable(
                name: "PostMultimedias",
                schema: "media");

            migrationBuilder.DropTable(
                name: "ProductContents",
                schema: "content");

            migrationBuilder.DropTable(
                name: "MultiMediaFileLocalizations",
                schema: "localization");

            migrationBuilder.DropTable(
                name: "ProductMultiMedias",
                schema: "media");

            migrationBuilder.DropTable(
                name: "Rates");

            migrationBuilder.DropTable(
                name: "ShippingMethods",
                schema: "selling_setting");

            migrationBuilder.DropTable(
                name: "ShippingZones",
                schema: "selling_setting");

            migrationBuilder.DropTable(
                name: "StoreAddresses",
                schema: "store_setting");

            migrationBuilder.DropTable(
                name: "Currencies",
                schema: "base");

            migrationBuilder.DropTable(
                name: "StoreGeneralSettings",
                schema: "store_setting");

            migrationBuilder.DropTable(
                name: "StoreSliders",
                schema: "store_setting");

            migrationBuilder.DropTable(
                name: "StoreGroups",
                schema: "store_setting");

            migrationBuilder.DropTable(
                name: "Tags",
                schema: "tag");

            migrationBuilder.DropTable(
                name: "ZarinPalSettings",
                schema: "payment_method");

            migrationBuilder.DropTable(
                name: "Comments",
                schema: "comment");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "MenuMultiMedias",
                schema: "media");

            migrationBuilder.DropTable(
                name: "PostCategories",
                schema: "post");

            migrationBuilder.DropTable(
                name: "Invoices",
                schema: "order");

            migrationBuilder.DropTable(
                name: "ZoneRegions",
                schema: "selling_setting");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "base");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "product");

            migrationBuilder.DropTable(
                name: "Posts",
                schema: "post");

            migrationBuilder.DropTable(
                name: "Coupons",
                schema: "selling");

            migrationBuilder.DropTable(
                name: "ShoppingCards",
                schema: "order");

            migrationBuilder.DropTable(
                name: "Proviences",
                schema: "base");

            migrationBuilder.DropTable(
                name: "Themes",
                schema: "site_setting");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "base");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "MultiMediaFiles",
                schema: "media");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "product");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Stores",
                schema: "store_setting");

            migrationBuilder.DropTable(
                name: "StoreTypes",
                schema: "store_setting");

            migrationBuilder.DropTable(
                name: "VariableProducts",
                schema: "product");

            migrationBuilder.DropTable(
                name: "DownloadableFiles",
                schema: "product");

            migrationBuilder.DropTable(
                name: "ShippingClasses",
                schema: "selling_setting");
        }
    }
}
