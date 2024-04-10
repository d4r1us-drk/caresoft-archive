package models

// Code generated by xo. DO NOT EDIT.

import (
	"context"
)

// SpMetodoPagoActualizar calls the stored procedure 'CaresoftDB.spMetodoPagoActualizar(int, varchar)' on db.
func SpMetodoPagoActualizar(ctx context.Context, db DB, pIDMetodoPago uint, pNombre string) error {
	// call CaresoftDB.spMetodoPagoActualizar
	const sqlstr = `CALL CaresoftDB.spMetodoPagoActualizar(?, ?)`
	// run
	logf(sqlstr)
	if _, err := db.ExecContext(ctx, sqlstr, pIDMetodoPago, pNombre); err != nil {
		return logerror(err)
	}
	return nil
}
