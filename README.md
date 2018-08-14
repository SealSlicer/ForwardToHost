# ForwardToHost
Forwards web requests to the configured host.
Used to forward web requests to a local https client.  Especially useful with ngrok.
## Setup Host
Update the web.config file "ForwardHost" for your target host.

## Setup ngrok
ngrok ngrok http --host-header="localhost:61179" 61179
The default port in the project is 61179.



