import {AbstractControl} from '@angular/forms';

export function goalinputValidator(
  control:AbstractControl
): { [key:string]:any} | null {
  const valid = /^[A-Za-z ]+$/.test(control.value)
  return valid
    ? null
    : {invalidInput:{ valid: false, value:control.value}}
}
