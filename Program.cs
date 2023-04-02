var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
        name: "Area",
        pattern: "{Area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ClientPanel}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "Dashboard",
    defaults: new { Controller = "Dashboard", action = "Index" });

//app.MapControllerRoute(
//    name: "one",
//    pattern: "Languages/{LanguageUrl}",
//    defaults:new {Controller="ClientPanel",action="LanguageDetails"}
//    );

//app.MapControllerRoute(
//    name: "ProgramLanguage",
//    pattern: "Languages/{LanguageUrl}/Programs/{ProgramUrl}",
//    defaults: new { Controller = "ClientPanel", action = "ProgramDetails" }
//    );
//app.MapControllerRoute(
//	name: "two",
//	pattern: "Programs/{ProgramUrl}",
//	defaults: new { Controller = "ClientPanel", action = "ProgramDetails"}
//	);

//app.MapControllerRoute(
//    name: "Topics",
//    pattern: "Topics",
//    defaults: new { Controller = "ClientPanel", action = "AllTopics" });

//app.MapControllerRoute(
//    name: "TopicsDetails",
//    pattern: "Topics/{TopicID}",
//    defaults: new { Controller = "ClientPanel", action = "TopicDetails" });

//app.MapControllerRoute(
//    name: "ProgramByTopic",
//    pattern: "Topics/{TopicID}/Programs/{ProgramUrl}",
//    defaults: new { Controller = "ClientPanel", action = "ProgramDetails" });

//app.MapControllerRoute(
//    name: "Programs",
//    pattern: "Programs",
//    defaults: new { Controller = "ClientPanel", action = "AllPrograms" });
//app.MapControllerRoute(
//    name: "Languages",
//    pattern: "Languages",
//    defaults: new { Controller = "ClientPanel", action = "AllLanguages" });




app.Run();
