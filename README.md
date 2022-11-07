# GaCloudServer.Admin
L'obiettivo è quello di creare una piattaforma centralizzata per la gestione delle esigenze specifiche e dei dati di Gestione Ambiente S.p.A.  


Tecologie Utilizzate: 
 - Skoruba.AdminUi 
 - Duende.IdentityServer
 - Oidc
 - .Net 6.0
 - Angular 15.0
 - Fuse 15.0 (Framework grafico Front-End)
 
 Struttura Progetto:  
 # GaCloudServer.Admin.STS.Identity 

  > Endpoint Autenticazione

  Sfruttando la tecnologia Duente.IdentityServer abbiamo costruito un server di autenticazione centralizzato che sfrutta il protocollo OIDC per autenticare gli utenti     dai vari client autorizzati.
  
  # GaCloudServer.Admin
  
  > Interfaccia Gestione
  
  Sfruttando la tecnologia Skoruba.AdminUi abbiamo creato l'interfaccia per gestire gli utenti, i client, e tutti i valori(scope, resources ecc..) per garantire la sicurezza applicativa


 

