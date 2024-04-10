package models

// Code generated by xo. DO NOT EDIT.

import (
	"context"
)

// SpAseguradoraEliminar calls the stored procedure 'CaresoftDB.spAseguradoraEliminar(int)' on db.
func SpAseguradoraEliminar(ctx context.Context, db DB, pIDAseguradora uint) error {
	// call CaresoftDB.spAseguradoraEliminar
	const sqlstr = `CALL CaresoftDB.spAseguradoraEliminar(?)`
	// run
	logf(sqlstr)
	if _, err := db.ExecContext(ctx, sqlstr, pIDAseguradora); err != nil {
		return logerror(err)
	}
	return nil
}
