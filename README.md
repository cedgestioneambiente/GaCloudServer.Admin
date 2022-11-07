# GaCloudServer.Admin
L'obiettivo è quello di creare una piattaforma centralizzata per la gestione delle esigenze specifiche e dei dati di Gestione Ambiente S.p.A.  


Tecologie Utilizzate: 
 - Skoruba.AdminUi 
 - Duende.IdentityServer
 - Oidc
 - .Net 6.0
 - EntityFramework 6.0
 - Angular 15.0
 - Fuse 15.0 (Framework grafico Front-End)
 
 Struttura Progetto:  
 # GaCloudServer.Admin.STS.Identity 

  > Endpoint Autenticazione

  Sfruttando la tecnologia Duente.IdentityServer abbiamo costruito un server di autenticazione centralizzato che sfrutta il protocollo OIDC per autenticare gli utenti     dai vari client autorizzati.
  
  # GaCloudServer.Admin
  
  > Interfaccia Gestione
  
  Sfruttando la tecnologia Skoruba.AdminUi abbiamo creato l'interfaccia per gestire gli utenti, i client, e tutti i valori(scope, resources ecc..) per garantire la sicurezza applicativa.
  
  # GaCloud.Admin.EntityFramework.Shared
  
  > Struttura Dati
  
  Sfruttando la tecnologia EntityFramework 6.0 abbiamo costruito la base dati di primo livello per la gestione dei dati (DB).
  Abbiamo strutturato in modo da poter utilizzare in futuro scenari in multipiatraforma (MS SQl,MySql,PostgreSQL).
  Abbiamo indirizzato il progetto su MS SQL.
  Le migrazioni vengono storate sul Progetto GaCloud.Admin.EntityFramework.SqlServer.
  
  # GaCloudServer.Admin.Api
  
  > Api Amministrative
  
  Abbiamo creato un progetto per la gestione delle Api a livello amministrativo, testabili tramite interfaccia Swagger integrate (Abilitabile e diabilitabile).
  
  # GaCloudServer.Resources.Api
  
  > Api Applicativi
  
  Abbiamo creato un progetto per la gestione delle Api a livello applicativo, testabili tramite interfaccia Swagger integrate (Abilitabile e diabilitabile).
  
  # GaCloudServer.BusinnessLogic
  
  > Logica di Businness
  
  Su questo progetto è presente tutta la logica di businness, implementazione dei Services a livello applicativo e gestione degli oggetti tramite Dto.
  
  ## Utilizzo:
  > Fasi preliminari:
  Clonare la repository: 


 

