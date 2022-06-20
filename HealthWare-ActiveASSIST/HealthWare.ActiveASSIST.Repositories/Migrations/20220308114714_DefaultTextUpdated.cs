using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class DefaultTextUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 2L,
                column: "LeftContent",
                value: "Please enter your 5 digit zip code.");

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 3L,
                column: "LeftContent",
                value: "Please tell us about your citizenship status. This will assist in determining potential programs that may be eligible for.");

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 4L,
                column: "LeftContent",
                value: "Please tell us more about the patient. Verify that the information displayed is correct and make any necessary corrections.");

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 5L,
                column: "LeftContent",
                value: "Please tell us if you are currently covered by health insurance or if you were covered in the last 60 days, either as a subscriber or as a dependent. If Yes, please provide information from your insurance card.");

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 6L,
                column: "LeftContent",
                value: "Please tell us about your household. Enter the total number of members that reside in your household.Please include the number of children under the age of 18 that are under your custody. Please indicate if you or anyone in your household is currently employed. Please check any of the listed benefits that you are currently receiving.If none apply, simply click NEXT to move to the next question");

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 7L,
                column: "LeftContent",
                value: "Let us know the total income & resources of your household.  Please includes all sources of income and the frequency that you receive the income.");

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 8L,
                column: "LeftContent",
                value: "Please let us know if any of the following apply to you  This includes health conditions and circumstances related to your illness / injury.");

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 9L,
                column: "LeftContent",
                value: "Please let us know if any of the following apply to you  This includes health conditions and circumstances related to your illness / injury.");

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 10L,
                column: "LeftContent",
                value: "Please let us know if any of the following apply to you  This includes health conditions and circumstances related to your illness / injury.");

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 11L,
                column: "LeftContent",
                value: "Please provide the Social Security Number of the person applying for assistance. If the person applying does not have a Social Security Number, enter reason for no SSN.");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$n3jwbsrSD2x.JoYK/VumTuMR.PcfUHVNnEFdJqdoyUQRBrgFoFffy");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$ckoA4XzAETK3kqkBBgE2Auh26iIYxFYUYLtwUmahWTbPO3506hCvm");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$ELIYyLqMnK5KvMiV1dB5h.H6p2x/ybo9B0TT4b8T.kDGwDQnpmAGi");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$Cn0zua0OJKyoimdGjwi2IO5743AHqgf3TwqZw4SCt9uPNpJz1jg5O");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$ipsqrzYFpV8sqRPnFFTBX.UjrVl1T6LN24JpW/y3MJvPoUtRpGwz.");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$r/JLUTIQlzf5UbRrB1g.zOJ8MYQ11UtW7eJTItBpn07vquLF1mYt2");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$fWGpSr.WXRT.a8ytChsNjumTCMk8ZBVNr6C7ovGvEe834uJrwierq");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 2L,
                column: "LeftContent",
                value: "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.");

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 3L,
                column: "LeftContent",
                value: "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.");

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 4L,
                column: "LeftContent",
                value: "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.");

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 5L,
                column: "LeftContent",
                value: "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.");

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 6L,
                column: "LeftContent",
                value: "Let us know the total number of members in your household.");

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 7L,
                column: "LeftContent",
                value: "Let us know the total income & resources of your household. It includes the income & resources of your & your household members also.");

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 8L,
                column: "LeftContent",
                value: "Kindly answer few questions to help you better. The questions includes on your health conditions.");

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 9L,
                column: "LeftContent",
                value: "Kindly answer few questions to help you better. The questions includes on your health conditions.");

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 10L,
                column: "LeftContent",
                value: "Kindly answer few questions to help you better. The questions includes on your health conditions.");

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 11L,
                column: "LeftContent",
                value: "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$UThyHXUABR/94/mpMzMAgebdBIAtdZ9Px3nDXwPRaEnZY5PUESWaO");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$n0FtCa6SRTb4LTXmo6YiVeBgvttKb/TTVd.ienO5cAmjT9NB.YtiS");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$euDwdT53JoxVHQ3pCSKmZuZBF.LeihmrK3eAtvKFKOAEYHvWA/FGG");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$XHF5XuaTgro4jNJPWZnJFepVYxzT7.fG111mlFFRSlt2FhTf6W0XO");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$zfEhmolrl9d21CDtbc3JxuBusP.24jooUQN8jR1CN49CYUmzWsk7u");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$B9vReqlSY70GLGMcSaAUDOMSqYa0zHuHvzLXLWsM9fc6Y/Pgrn25u");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$LBjvb6F38hP4c2WqJGvcCOY9tXdriquUoBZMWBU.sD7b/GC66zGeS");
        }
    }
}
