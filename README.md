# Iron Maiden - Registry

A Web API project to create, read, update and delete basic information's from the best band ever.

<h2>Tools</h2>

- .NET 8<br/>
- SQL Server 2022<br/>

<div style="display: inline_block" class="flex-container"><br>
    <img align="center" alt="dotnet" height="5%" width="5%" <img
            src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dotnetcore/dotnetcore-original.svg" />
    <img align="center" alt="mssql" height="5%" width="5%" <img
            src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/microsoftsqlserver/microsoftsqlserver-plain-wordmark.svg" />
    <img align="center" alt="Docker" height="5%" width="5%" <img
            src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/docker/docker-original.svg" />
    <img align="center" alt="vscode" height="5%" width="5%" <img
            src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/vscode/vscode-original.svg" />
</div>

<h2>NuGet Packages</h2>

- Microsoft.EntityFrameworkCore<br/>
- Microsoft.EntityFrameworkCore.Design<br/>
- Microsoft.EntityFrameworkCore.SqlServer<br/>
- Swashbuckle.AspNetCore

<h2>Endpoints</h2>
<ul>
  <h3>Instruments</h3>
  <li>Get: <code>/api/Instruments</code></li>
  <li>Post: <code>/api/Instruments</code></li>
    <ul>
       <li>Expected body: <code>{ name: "string" }</code></li>
    </ul>
  <li>GetById: <code>/api/Instruments/{id}</code></li>
  <li>Patch: <code>/api/Instruments/{id}</code></li>
    <ul>
       <li>Expected body: <code>{ name: "string" }</code></li>
    </ul>
  <li>Delete: <code>/api/Instruments/{id}</code></li> <br/>
  <h3>Members</h3>
  <li>Get: <code>/api/Members</code></li>
  <li>Post: <code>/api/Members</code></li>
    <ul>
       <li>Expected body: <code>{ "fullName": "string", "birthDate": "2023-12-30", "instrumentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6" }</code></li>
    </ul>
  <li>GetById: <code>/api/Members/{id}</code></li>
  <li>Patch: <code>/api/Members/{id}</code></li> 
     <ul>
        <li>Expected body: <code>{ "fullName": "string", "birthDate": "2023-12-30", "instrumentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6" }</code></li>
     </ul>
  <li>Delete: <code>/api/Instruments/{id}</code></li<br/>
  <h3>Songs</h3>
  <li>Get: <code>/api/Songs</code></li>
  <li>Post: <code>/api/Songs</code></li>
   <ul>
      <li>Expected body: <code>{ "fullName": "string", "birthDate": "2023-12-30", "instrumentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6" }</code></li>
   </ul>
  <li>GetById: <code>/api/Songs/{id}</code></li>
  <li>Patch: <code>/api/Songs/{id}</code></li> 
  <ul>
      <li>Expected body: <code>{ "fullName": "string", "birthDate": "2023-12-30", "instrumentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6" }</code></li>
   </ul>
  <li>Delete: <code>/api/Songs/{id}</code></li<br/>
</ul>  

<span><strong>Up the Iron's!</strong></span>