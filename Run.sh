#!/usr/bin/env bash
qemu-system-x86_64 -cdrom bin/net6.0/mosaic.iso -cpu max -m 1G -enable-kvm -serial stdio