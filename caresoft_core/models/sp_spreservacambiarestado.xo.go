package models

// Code generated by xo. DO NOT EDIT.

import (
	"context"
)

// SpReservaCambiarEstado calls the stored procedure 'CaresoftDB.spReservaCambiarEstado(int)' on db.
func SpReservaCambiarEstado(ctx context.Context, db DB, pIDReserva uint) error {
	// call CaresoftDB.spReservaCambiarEstado
	const sqlstr = `CALL CaresoftDB.spReservaCambiarEstado(?)`
	// run
	logf(sqlstr)
	if _, err := db.ExecContext(ctx, sqlstr, pIDReserva); err != nil {
		return logerror(err)
	}
	return nil
}
