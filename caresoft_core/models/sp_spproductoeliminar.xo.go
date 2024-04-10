package models

// Code generated by xo. DO NOT EDIT.

import (
	"context"
)

// SpProductoEliminar calls the stored procedure 'CaresoftDB.spProductoEliminar(int)' on db.
func SpProductoEliminar(ctx context.Context, db DB, pIDProducto uint) error {
	// call CaresoftDB.spProductoEliminar
	const sqlstr = `CALL CaresoftDB.spProductoEliminar(?)`
	// run
	logf(sqlstr)
	if _, err := db.ExecContext(ctx, sqlstr, pIDProducto); err != nil {
		return logerror(err)
	}
	return nil
}
