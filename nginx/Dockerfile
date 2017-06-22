FROM nginx

COPY nginx.conf /etc/nginx/nginx.conf
COPY ./ssl /etc/nginx/ssl
COPY ./start.sh ./

EXPOSE 80
EXPOSE 443

CMD ["./start.sh"]