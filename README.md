# PostgresLogger

Create Postgres table using the following:

```
CREATE TABLE public.jsonlogs
(
   id SERIAL PRIMARY KEY,
   info json NOT NULL

)
```
