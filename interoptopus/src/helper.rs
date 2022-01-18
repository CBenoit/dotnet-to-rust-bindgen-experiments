macro_rules! err_check {
    ($expr:expr) => {{
        match $expr {
            Ok(v) => v,
            Err(e) => return e.into(),
        }
    }};
}

macro_rules! none_check {
    ($opt:expr) => {
        if let Some(val) = $opt {
            val
        } else {
            return ::interoptopus::patterns::result::FFIError::NULL;
        }
    };
}

