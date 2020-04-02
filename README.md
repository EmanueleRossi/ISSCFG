# ISSCFG
Infinity Self Service Configurator

## DOCKER
Log-in to an image
<code>docker exec -it <container name> /bin/bash</code>

## DATABASE
### CLI ef tool install...
<code>dotnet tool install --global dotnet-ef</code>

<code>dotnet add package Microsoft.EntityFrameworkCore.Design</code>

### Initial DB Creation
<code>$Env:ASPNETCORE_ENVIRONMENT = "Development"</code>

<code>dotnet ef migrations add InitialCreate</code>

<code>dotnet ef database update -v</code>

### PostgreSQL PSQL Snippets
Connect to a database: <code>connect isscfg</code>
Show all users: <code>\du</code>
Show all databases: <code>\l</code>
Show all schemas: <code>\dn</code>
Show all tables: <code>\lt</code>

### Postgres SQL Snippets
Change database owner: <code>ALTER DATABASE isscfg OWNER TO postgres;</code>
Disconnect all users from db: <code>SELECT pg_terminate_backend(pid) FROM pg_stat_activity WHERE datname = 'isscfg';</code>
Drop database: <code>drop database isscfg;</code>

## DEPLOYMENT
### Show
<code>gcloud container images list</code>

<code>gcloud container images delete</code>

<code>gcloud container images list-tags gcr.io/isscfg/github.com/emanuelerossi/isscfg --format='get(digest,timestamp)'</code>

### Google Cloud Run Deployment
<code>gcloud run deploy isscfg --region=europe-west1 --platform=managed --allow-unauthenticated --timeout=10s --image=gcr.io/isscfg/github.com/emanuelerossi/isscfg@sha256:8d1a3717acfa4134e3ffd92ce580cde145869cdd2d9a90f4d24cf4aede312361</code>
