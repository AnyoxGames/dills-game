13
4071628996609
404968201574197 1761863313660601300
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -4.9538455009460449,
    "Y": -10.9883184432983398
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404964696299752:1761863312843868200",
  "next_sibling": "404970775650495:1761863314260363400",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404968202026385:1761863313660705400",
  "component_type": "Internal_Component",
  "internal_component_type": "Interactable",
  "data": {
    "text": "Harvest Pine Tree",
    "radius": 1,
    "required_hold_time": 0.3000000119209290
  }
},
{
  "cid": 4,
  "aoid": "404968202187678:1761863313660742900",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404968202026385:1761863313660705400",
    "DefaultRenderer": "404968202282751:1761863313660765100",
    "DepletedRenderer": "404968202244180:1761863313660756100"
  }
},
{
  "cid": 5,
  "aoid": "404968202210941:1761863313660748400",
  "component_type": "Internal_Component",
  "internal_component_type": "Polygon_Collider",
  "data": {
    "make_navmesh_loop": true,
    "flip_navmesh_loop": true,
    "points": [
      {
        "X": -0.1877212524414062,
        "Y": -0.2063050270080566
      },
      {
        "X": 0.0189009904861450,
        "Y": -0.2597980499267578
      },
      {
        "X": 0.2158927917480469,
        "Y": -0.1123766899108887
      },
      {
        "X": 0.0703394412994385,
        "Y": 0.1123763322830200
      },
      {
        "X": -0.1783308982849121,
        "Y": 0.0560193061828613
      }
    ]
  }
}
