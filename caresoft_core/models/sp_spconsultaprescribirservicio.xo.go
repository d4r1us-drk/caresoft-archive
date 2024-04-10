package models

// Code generated by xo. DO NOT EDIT.

import (
	"context"
)

// SpConsultaPrescribirServicio calls the stored procedure 'CaresoftDB.spConsultaPrescribirServicio(varchar, varchar)' on db.
func SpConsultaPrescribirServicio(ctx context.Context, db DB, pConsultaCodigo, pServicioCodigo string) error {
	// call CaresoftDB.spConsultaPrescribirServicio
	const sqlstr = `CALL CaresoftDB.spConsultaPrescribirServicio(?, ?)`
	// run
	logf(sqlstr)
	if _, err := db.ExecContext(ctx, sqlstr, pConsultaCodigo, pServicioCodigo); err != nil {
		return logerror(err)
	}
	return nil
}
