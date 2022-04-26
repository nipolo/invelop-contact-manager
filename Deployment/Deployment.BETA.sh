cd ~
rm -rf invelop-contact-manager
git clone https://github.com/nipolo/invelop-contact-manager
cd ~/invelop-contact-manager
docker stop invelop-contact-manager-beta
docker rm invelop-contact-manager-beta
docker build -f Api/ContactManager/Dockerfile.BETA -t invelop-contact-manager-beta/latest .
docker run --name invelop-contact-manager-beta -d -p 3001:80 --restart unless-stopped -e ASPNETCORE_ENVIRONMENT=BETA -e TZ=Europe/Sofia invelop-contact-manager-beta/latest