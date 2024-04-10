package models

// Code generated by xo. DO NOT EDIT.

import (
	"context"
)

// SpProductoCrear calls the stored procedure 'CaresoftDB.spProductoCrear(varchar, varchar, decimal, int)' on db.
func SpProductoCrear(ctx context.Context, db DB, pNombre, pDescripcion string, pCosto float64, pLoteDisponible uint) error {
	// call CaresoftDB.spProductoCrear
	const sqlstr = `CALL CaresoftDB.spProductoCrear(?, ?, ?, ?)`
	// run
	logf(sqlstr)
	if _, err := db.ExecContext(ctx, sqlstr, pNombre, pDescripcion, pCosto, pLoteDisponible); err != nil {
		return logerror(err)
	}
	return nil
}
