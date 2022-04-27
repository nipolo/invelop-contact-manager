cd ~
rm -rf invelop-contact-manager
git clone https://github.com/nipolo/invelop-contact-manager
cd ~/invelop-contact-manager
docker stop invelop-contact-manager
docker rm invelop-contact-manager
docker build -f ContactManager/Api/Dockerfile.BETA -t invelop-contact-manager/latest .
docker run --name invelop-contact-manager -d -p 3001:80 --restart unless-stopped -e ASPNETCORE_ENVIRONMENT=BETA -e TZ=Europe/Sofia invelop-contact-manager/latest