# ForwardToHost

* Forwards web requests received to the configured host, and returns the raw response message.
* Used to forward web requests to a local https client.  Especially useful with ngrok.
  * This solves the "502 bad gateway" errors with running a free ngrok account when trying to access an https site hosted on iis/iisexpress.
   * ngrok does not forward https traffic as https.

## Setup Host
Update the web.config file "ForwardHost" for your target host.

## Setup ngrok
ngrok ngrok http --host-header="localhost:61179" 61179
The default port in the project is 61179.



