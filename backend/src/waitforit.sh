#!/bin/sh

wait_for_mysql() {
    HOST="$1"
    PORT="$2"
    USER="$3"
    PASSWORD="$4"
    SLEEP_INTERVAL=3
    MAX_ATTEMPTS=20

    echo "Waiting for MySQL to become available..."

    i=0
    while [ $i -lt $MAX_ATTEMPTS ]; do

        if mysqladmin ping -h"$HOST" -P"$PORT" -u"$USER" -p"$PASSWORD" &> /dev/null; then
            echo "MySQL is available!"
            return 0
        fi

        sleep $SLEEP_INTERVAL
        i=$((i+1))
    done

    echo "ERROR: MySQL is not available after $((MAX_ATTEMPTS * SLEEP_INTERVAL)) seconds."
    return 1
}

wait_for_mysql "$1" "$2" "$3" "$4"