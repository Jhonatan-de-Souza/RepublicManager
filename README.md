# RepublicManager (API Only) #
### Must be used with [Republic Manager-UI](https://github.com/Jhonatan-de-Souza/RepublicManager-UI)

App to manage expenses and daily task in a shared location

# Technologies Used
1. .Net Core 2.1
2. Docker (SQL Server Container)
3. Repository Pattern
4. JWT Authentication(Roles)
5. Entity Migrations


# How To run ##

1. Clone Project
2. Open in Visual Studio
3. Build Solution
4. Create SQL Server Database called "Republic Manager" (Without Quotes)
5. Open Package Manager Console and run command `dotnet ef database update`
6. API routes:

### API Routes & Verbs ###

(`POST`) Login: `http://localhost:61209/api/login`
(`GET/POST/PUT/DELETE`) Roles: `http://localhost:61209/api/role`
(`GET/POST/PUT/DELETE`) Usuário: `http://localhost:61209/api/usuario`
(`GET/POST/PUT/DELETE`) Republica: `http://localhost:61209/api/republica`
(`GET/POST/PUT/DELETE`) Aviso: `http://localhost:61209/api/aviso `
(`GET/POST/PUT/DELETE`) CarrinhoDeCompra: `http://localhost:61209/api/CarrinhoDeCompra`
(`GET/POST/PUT/DELETE`) ContaAPagar: `http://localhost:61209/api/ContaAPagar`
(`GET/POST/PUT/DELETE`) ContaAReceber: `http://localhost:61209/api/ContaAReceber`
(`GET/POST/PUT/DELETE`) Conta: `http://localhost:61209/api/Conta`
(`GET/POST/PUT/DELETE`) Produto: `http://localhost:61209/api/Produto`
(`GET/POST/PUT/DELETE`) Regra: `http://localhost:61209/api/Regra`
(`GET/POST/PUT/DELETE`) Tarefa: `http://localhost:61209/api/Tarefa`
(`GET/POST/PUT/DELETE`) TipoConta: `http://localhost:61209/api/TipoConta`



