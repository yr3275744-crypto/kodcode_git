FROM python:3.13.13-slim
WORKDIR /app
COPY  . .
RUN pip install -r requerments.txt
CMD [ "python", "producer.py" ]