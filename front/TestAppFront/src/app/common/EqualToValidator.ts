import { FormGroup } from '@angular/forms';

export function EqualToValidator(controlOneName: string, controlTwoName: string) {
	return (formGroup: FormGroup) => {
		const controlOne = formGroup.controls[controlOneName];
		const controlTwo = formGroup.controls[controlTwoName];
		if (controlTwo.errors && !controlTwo.errors['confirmedValidator']) {
			return;
		}
		if (controlOne.value !== controlTwo.value) {
			controlTwo.setErrors({ confirmedValidator: true });
		} else {
			controlTwo.setErrors(null);
		}
	};
}
