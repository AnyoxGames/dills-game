13
4286377361409
404991949140405 1761863319193808400
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": 4.2606086730957031,
    "Y": -9.8552179336547852
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404989374287415:1761863318593864900",
  "next_sibling": "405007184708670:1761863322743711600",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404991949379571:1761863319193863200",
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
  "aoid": "404991949505346:1761863319193892500",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404991949379571:1761863319193863200",
    "DefaultRenderer": "404991949552646:1761863319193903600",
    "DepletedRenderer": "404991949537123:1761863319193899900"
  }
},
{
  "cid": 5,
  "aoid": "404991949517988:1761863319193895500",
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
