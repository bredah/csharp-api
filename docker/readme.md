# Cassandra

## Docker

```bash
docker-compose up -d
```

### Check status

Command:

```bash
docker exec cassandra nodetool status
```

Output:

```console
Datacenter: datacenter1
=======================
Status=Up/Down
|/ State=Normal/Leaving/Joining/Moving
--  Address     Load       Tokens       Owns (effective)  Host ID                               Rack
UN  172.18.0.2  103.65 KiB  256          100.0%            67524dc2-0527-4990-bcb0-e550a48d161a  rack1
```

> The important information in the results part of the command are the two letters at the beginning of each node line. It should be **UN**. **U** for Up and **N** for Normal.

## Access the cqlsh

```bash
docker exec -it cassandra cqlsh
```

### Create a key space

```cql
DROP KEYSPACE IF EXISTS bookstore;
-- Create KEYSPACE
CREATE KEYSPACE bookstore WITH REPLICATION = { 'class' : 'SimpleStrategy', 'replication_factor' : 1 };
```

### Create a table

```cql
CREATE TABLE IF NOT EXISTS bookstore.book (
    id UUID PRIMARY KEY,
    title text,
    genre text,
    author text
);
```