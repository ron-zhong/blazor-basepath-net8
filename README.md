**How to run a .NET 8 Blazor Web App (Interactive Server + WebAssembly) under a different path, like '/path-prefix/'?**
- Before: All the assembly and resource files were under https://localhost:7196/
- After:  All the assembly and resource files are now under https://localhost:7196/path-prefix/ 
![image](https://github.com/ron-zhong/custom-app-basepath/assets/43414651/387b62c6-40ba-400d-ae84-807aa6f25dfa)

**Solution:**
![image](https://github.com/ron-zhong/custom-app-basepath/assets/43414651/105285c0-0717-4aaf-abe0-fa5fbf2bb917)

Step 1: Making sure these 4 lines are added in server project program.cs:
- app.UseStaticFiles("/path-prefix");
- app.UsePathBase("/path-prefix");
- app.UseAntiforgery();
- app.UseRouting();

Step 2: Change base path in App.razor from "/" to:
- "/path-prefix/"
