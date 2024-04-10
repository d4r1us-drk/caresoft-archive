package models

// Code generated by xo. DO NOT EDIT.

import (
	"context"
)

// SpConsultaEliminar calls the stored procedure 'CaresoftDB.spConsultaEliminar(varchar)' on db.
func SpConsultaEliminar(ctx context.Context, db DB, pConsultaCodigo string) error {
	// call CaresoftDB.spConsultaEliminar
	const sqlstr = `CALL CaresoftDB.spConsultaEliminar(?)`
	// run
	logf(sqlstr)
	if _, err := db.ExecContext(ctx, sqlstr, pConsultaCodigo); err != nil {
		return logerror(err)
	}
	return nil
}
