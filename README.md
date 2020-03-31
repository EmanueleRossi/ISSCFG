# ISSCFG
Infinity Self Service Configurator

## Google Cloud Run Deployment
gcloud run deploy isscfg --region=europe-west1 --platform=managed --allow-unauthenticated --timeout=10s --image=gcr.io/isscfg/github.com/emanuelerossi/isscfg@sha256:90769f4746b3c9322a290ff925e2c6b80f0e127ded5576293bc820fcee0efbf9

## Initial DB Creation
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialCreate
dotnet ef database update

## PostgreSQL Snippets
Connect to a database:
<code>connect isscfg</code>

Show all users:
<code>\du</code>

Show all databases:
<code>\l</code>

Show all schemas:
<code>\dn</code>

Show all tables:
<code>\lt</code>
