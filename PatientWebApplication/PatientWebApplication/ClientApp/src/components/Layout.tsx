import * as React from 'react';
import { Container } from 'reactstrap';
import NavMenu from './NavMenu';
import { Route } from 'react-router';
import Home from '../components/Home';
import PatientFeedback from './PatientFeedback';
import AdminFeedback from './AdminFeedback';
import CreateFeedback from './CreateFeedback';
import PrescriptionsSimple from './PrescriptionsSimple';
import AppointmentReportSimpleSearch from './AppointmentReportSimpleSearch';
import RegistrationOfPatient from './PatientRegister';
import MyInformation from './MyInformation';

export default (props: { children: React.ReactNode }) => (
    <React.Fragment>
        <NavMenu/>
        <Container>
            <Route exact path='/' component={Home} />
            <Route path='/patient-feedback' component={PatientFeedback} />
            <Route path='/admin-feedback' component={AdminFeedback} />
            <Route path='/create-feedback' component={CreateFeedback} />
            <Route path='/prescriptions-simple' component={PrescriptionsSimple} />
            <Route path='/reports-simple' component={AppointmentReportSimpleSearch} />
            <Route path='/register-patient' component={RegistrationOfPatient} />
            <Route path='/my-information' component={MyInformation} />
        </Container>
    </React.Fragment>
);
