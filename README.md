# ISSCFG
Infinity Self Service Configurator

## Google Cloud Run Deployment
gcloud builds submit --tag gcr.io/isscfg/cfg

## Google Cloud Deploy to Cloud RUN
gcloud run deploy --image gcr.io/ISSCFG/isscfg --platform managed