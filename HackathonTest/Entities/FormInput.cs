﻿using System;
using System.Collections.Generic;

namespace HackathonTest.Entities;

public partial class FormInput
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int FormSectionId { get; set; }

    public virtual FormSection FormSection { get; set; } = null!;
}
