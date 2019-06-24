using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "Addseq",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "Certseq",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "Commseq",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "Msgseq",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "Notiseq",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "Promoseq",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "Reposeq",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "Roleseq",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "Specseq",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "Transeq",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "Userseq",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Number = table.Column<string>(nullable: false),
                    Card_Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Number);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Percentage = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    ExpireDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Role_Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Spc_Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Fname = table.Column<string>(maxLength: 15, nullable: false),
                    Lname = table.Column<string>(maxLength: 15, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    Rate = table.Column<float>(nullable: false, defaultValue: 0f),
                    Image = table.Column<string>(nullable: true),
                    Widget = table.Column<int>(nullable: false, defaultValue: 0),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Deleted = table.Column<bool>(nullable: true, defaultValue: false),
                    Role_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_Role_Id",
                        column: x => x.Role_Id,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    AddressType = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Region = table.Column<string>(nullable: false),
                    street = table.Column<string>(nullable: false),
                    Usr_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_Usr_Id",
                        column: x => x.Usr_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Desc = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Rate = table.Column<float>(nullable: false),
                    Deleted = table.Column<bool>(nullable: true, defaultValue: false),
                    UserFrom_Id = table.Column<int>(nullable: false),
                    UserTo_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserFrom_Id",
                        column: x => x.UserFrom_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserTo_Id",
                        column: x => x.UserTo_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    ESSN = table.Column<string>(fixedLength: true, maxLength: 14, nullable: false),
                    Degree = table.Column<string>(nullable: false),
                    Bio = table.Column<string>(nullable: true),
                    OfficialCard = table.Column<string>(nullable: false),
                    Experience = table.Column<int>(nullable: false),
                    Verified = table.Column<bool>(nullable: false, defaultValue: false),
                    Salary = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false, defaultValue: false),
                    User_Id = table.Column<int>(nullable: false),
                    Card_Id = table.Column<string>(nullable: false),
                    Spec_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.ESSN);
                    table.ForeignKey(
                        name: "FK_Doctors_Cards_Card_Id",
                        column: x => x.Card_Id,
                        principalTable: "Cards",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_Specializations_Spec_Id",
                        column: x => x.Spec_Id,
                        principalTable: "Specializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Msg = table.Column<string>(nullable: false),
                    Read = table.Column<bool>(nullable: true, defaultValue: false),
                    Delievered = table.Column<bool>(nullable: true, defaultValue: false),
                    Deleted = table.Column<bool>(nullable: true, defaultValue: false),
                    UserFrom_Id = table.Column<int>(nullable: false),
                    UserTo_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Users_UserFrom_Id",
                        column: x => x.UserFrom_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_Users_UserTo_Id",
                        column: x => x.UserTo_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OnlineUsers",
                columns: table => new
                {
                    Usr_Id = table.Column<int>(nullable: false),
                    ConnectionId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineUsers", x => new { x.ConnectionId, x.Usr_Id });
                    table.ForeignKey(
                        name: "FK_OnlineUsers_Users_Usr_Id",
                        column: x => x.Usr_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Usr_Id = table.Column<int>(nullable: false),
                    Number = table.Column<string>(fixedLength: true, maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => new { x.Usr_Id, x.Number });
                    table.ForeignKey(
                        name: "FK_Phones_Users_Usr_Id",
                        column: x => x.Usr_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Desc = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Zyara_Date = table.Column<DateTime>(nullable: false),
                    UserFrom_Id = table.Column<int>(nullable: false),
                    UserTo_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_Users_UserFrom_Id",
                        column: x => x.UserFrom_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reports_Users_UserTo_Id",
                        column: x => x.UserTo_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    QR_Code = table.Column<string>(nullable: true),
                    Accepted = table.Column<bool>(nullable: true),
                    Completed = table.Column<bool>(nullable: true),
                    Doctor_Id = table.Column<int>(nullable: false),
                    Patient_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_Doctor_Id",
                        column: x => x.Doctor_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_Patient_Id",
                        column: x => x.Patient_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserPromotions",
                columns: table => new
                {
                    User_Id = table.Column<int>(nullable: false),
                    Prom_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPromotions", x => new { x.Prom_Id, x.User_Id });
                    table.ForeignKey(
                        name: "FK_UserPromotions_Promotions_Prom_Id",
                        column: x => x.Prom_Id,
                        principalTable: "Promotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPromotions_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    TokenNumber = table.Column<string>(nullable: false),
                    Usr_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.TokenNumber, x.Usr_Id });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_Usr_Id",
                        column: x => x.Usr_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Certi_Img = table.Column<string>(nullable: false),
                    Certi_Title = table.Column<string>(nullable: false),
                    ESSN = table.Column<string>(fixedLength: true, maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificates_Doctors_ESSN",
                        column: x => x.ESSN,
                        principalTable: "Doctors",
                        principalColumn: "ESSN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Read = table.Column<bool>(nullable: true, defaultValue: false),
                    Tans_Id = table.Column<int>(nullable: false),
                    UserFrom_Id = table.Column<int>(nullable: false),
                    UserTo_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Transactions_Tans_Id",
                        column: x => x.Tans_Id,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserFrom_Id",
                        column: x => x.UserFrom_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserTo_Id",
                        column: x => x.UserTo_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_Usr_Id",
                table: "Addresses",
                column: "Usr_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_ESSN",
                table: "Certificates",
                column: "ESSN");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserFrom_Id",
                table: "Comments",
                column: "UserFrom_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserTo_Id",
                table: "Comments",
                column: "UserTo_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Card_Id",
                table: "Doctors",
                column: "Card_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Spec_Id",
                table: "Doctors",
                column: "Spec_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_User_Id",
                table: "Doctors",
                column: "User_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserFrom_Id",
                table: "Messages",
                column: "UserFrom_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserTo_Id",
                table: "Messages",
                column: "UserTo_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_Tans_Id",
                table: "Notifications",
                column: "Tans_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserFrom_Id",
                table: "Notifications",
                column: "UserFrom_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserTo_Id",
                table: "Notifications",
                column: "UserTo_Id");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineUsers_Usr_Id",
                table: "OnlineUsers",
                column: "Usr_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_UserFrom_Id",
                table: "Reports",
                column: "UserFrom_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_UserTo_Id",
                table: "Reports",
                column: "UserTo_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_Spc_Name",
                table: "Specializations",
                column: "Spc_Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_Doctor_Id",
                table: "Transactions",
                column: "Doctor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_Patient_Id",
                table: "Transactions",
                column: "Patient_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserPromotions_User_Id",
                table: "UserPromotions",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Role_Id",
                table: "Users",
                column: "Role_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_Usr_Id",
                table: "UserTokens",
                column: "Usr_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "OnlineUsers");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "UserPromotions");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropSequence(
                name: "Addseq");

            migrationBuilder.DropSequence(
                name: "Certseq");

            migrationBuilder.DropSequence(
                name: "Commseq");

            migrationBuilder.DropSequence(
                name: "Msgseq");

            migrationBuilder.DropSequence(
                name: "Notiseq");

            migrationBuilder.DropSequence(
                name: "Promoseq");

            migrationBuilder.DropSequence(
                name: "Reposeq");

            migrationBuilder.DropSequence(
                name: "Roleseq");

            migrationBuilder.DropSequence(
                name: "Specseq");

            migrationBuilder.DropSequence(
                name: "Transeq");

            migrationBuilder.DropSequence(
                name: "Userseq");
        }
    }
}
